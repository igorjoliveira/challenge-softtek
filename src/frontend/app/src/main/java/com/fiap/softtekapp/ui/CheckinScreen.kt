package com.fiap.softtekapp.ui

import androidx.compose.foundation.clickable
import androidx.compose.foundation.layout.*
import androidx.compose.foundation.lazy.*
import androidx.compose.material.icons.Icons
import androidx.compose.material.icons.filled.ArrowBack
import androidx.compose.material3.*
import androidx.compose.runtime.*
import androidx.compose.ui.Alignment
import androidx.compose.ui.Modifier
import androidx.compose.ui.unit.dp
import androidx.navigation.NavController
import com.fiap.softtekapp.data.model.*
import com.fiap.softtekapp.data.network.RetrofitInstance
import kotlinx.coroutines.launch
import java.time.LocalDate

@OptIn(ExperimentalMaterial3Api::class)
@Composable
fun CheckinScreen(navController: NavController) {
    val avaliacaoId = "01JVKE1RX5KAMJ0Q2TAEBY4X8V"
    var blocos by remember { mutableStateOf<List<BlocoDto>>(emptyList()) }
    var blocoAtualIndex by remember { mutableStateOf(0) }
    var loading by remember { mutableStateOf(true) }
    var error by remember { mutableStateOf<String?>(null) }
    var sucesso by remember { mutableStateOf(false) }
    val respostas = remember { mutableStateMapOf<String, String>() }
    val scrollState = rememberLazyListState()
    val scope = rememberCoroutineScope()

    LaunchedEffect(Unit) {
        scope.launch {
            try {
                val blocosResponse = RetrofitInstance.api.obterBlocosPorAvaliacao(avaliacaoId)
                val blocosComPerguntas = blocosResponse.map { bloco ->
                    val perguntas = RetrofitInstance.api.obterPerguntas(avaliacaoId, bloco.codigo)
                    bloco.copy(perguntas = perguntas)
                }.filter { it.perguntas.isNotEmpty() }
                blocos = blocosComPerguntas
            } catch (e: Exception) {
                error = e.localizedMessage
            } finally {
                loading = false
            }
        }
    }

    Scaffold(
        topBar = {
            CenterAlignedTopAppBar(
                title = { Text("Check-in Diário") },
                navigationIcon = {
                    IconButton(onClick = { navController.popBackStack() }) {
                        Icon(Icons.Default.ArrowBack, contentDescription = "Voltar")
                    }
                }
            )
        },
        bottomBar = {
            if (!loading && blocos.isNotEmpty() && blocoAtualIndex <= blocos.lastIndex) {
                val bloco = blocos[blocoAtualIndex]
                val todasRespondidas = bloco.perguntas.isNotEmpty() &&
                        bloco.perguntas.all { respostas[it.codigo] != null }

                Row(
                    horizontalArrangement = Arrangement.SpaceBetween,
                    modifier = Modifier
                        .fillMaxWidth()
                        .padding(16.dp)
                ) {
                    if (blocoAtualIndex > 0) {
                        Button(onClick = {
                            blocoAtualIndex--
                            scope.launch { scrollState.animateScrollToItem(0) }
                        }) {
                            Text("Anterior")
                        }
                    } else {
                        Spacer(modifier = Modifier.width(8.dp))
                    }

                    if (blocoAtualIndex < blocos.lastIndex) {
                        Button(
                            onClick = {
                                blocoAtualIndex++
                                scope.launch { scrollState.animateScrollToItem(0) }
                            },
                            enabled = todasRespondidas
                        ) {
                            Text("Avançar")
                        }
                    } else {
                        Button(
                            onClick = {
                                scope.launch {
                                    try {
                                        val data = LocalDate.now().toString()
                                        blocos.forEach { bloco ->
                                            val respostasDoBloco = bloco.perguntas.mapNotNull { pergunta ->
                                                respostas[pergunta.codigo]?.let { escalaId ->
                                                    RespostaItemDto(pergunta.codigo, escalaId)
                                                }
                                            }
                                            if (respostasDoBloco.isNotEmpty()) {
                                                val payload = RespostaFinalDto(
                                                    blocoDeRespostaId = bloco.codigo,
                                                    respostas = respostasDoBloco
                                                )
                                                RetrofitInstance.api.enviarRespostas(data, payload)
                                            }
                                        }
                                        sucesso = true
                                    } catch (e: Exception) {
                                        error = e.localizedMessage
                                    }
                                }
                            },
                            enabled = todasRespondidas
                        ) {
                            Text("Enviar")
                        }
                    }
                }
            }
        }
    ) { padding ->
        if (loading) {
            Box(
                modifier = Modifier
                    .padding(padding)
                    .fillMaxSize(),
                contentAlignment = Alignment.Center
            ) {
                CircularProgressIndicator()
            }
        } else if (error != null) {
            Text("Erro: $error", color = MaterialTheme.colorScheme.error)
        } else if (sucesso) {
            Box(
                modifier = Modifier
                    .padding(padding)
                    .fillMaxSize(),
                contentAlignment = Alignment.Center
            ) {
                Text("Formulário finalizado com sucesso!", style = MaterialTheme.typography.titleLarge)
            }
        } else if (blocos.isNotEmpty() && blocoAtualIndex <= blocos.lastIndex) {
            val bloco = blocos[blocoAtualIndex]

            LazyColumn(
                state = scrollState,
                modifier = Modifier
                    .padding(padding)
                    .fillMaxSize()
                    .padding(16.dp)
            ) {
                item {
                    val tituloValido = if (bloco.perguntas.isNotEmpty()) {
                        "${bloco.titulo} (${bloco.perguntas.size} perguntas)"
                    } else {
                        "Bloco sem perguntas"
                    }
                    Text(tituloValido, style = MaterialTheme.typography.titleLarge)
                    Spacer(modifier = Modifier.height(8.dp))
                }

                items(bloco.perguntas) { pergunta ->
                    Column(modifier = Modifier.padding(vertical = 8.dp)) {
                        Text(pergunta.descricao)
                        Spacer(modifier = Modifier.height(4.dp))
                        pergunta.valoresAceitos
                            .sortedBy { it.descricao }
                            .forEach { valor ->
                                Row(
                                    modifier = Modifier
                                        .fillMaxWidth()
                                        .padding(4.dp)
                                        .clickable {
                                            respostas[pergunta.codigo] = valor.codigo
                                        }
                                ) {
                                    RadioButton(
                                        selected = respostas[pergunta.codigo] == valor.codigo,
                                        onClick = {
                                            respostas[pergunta.codigo] = valor.codigo
                                        }
                                    )
                                    Text(valor.descricao, modifier = Modifier.padding(start = 8.dp))
                                }
                            }
                    }
                }

                if (blocoAtualIndex == blocos.lastIndex) {
                    item {
                        Spacer(modifier = Modifier.height(16.dp))
                        Text(
                            text = "Você chegou ao fim do formulário. Clique em 'Enviar' para finalizar.",
                            style = MaterialTheme.typography.bodyMedium,
                            color = MaterialTheme.colorScheme.primary
                        )
                    }
                }
            }
        }
    }
}
