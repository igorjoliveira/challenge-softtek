package com.fiap.softtekapp.ui

import androidx.compose.foundation.clickable
import androidx.compose.foundation.layout.*
import androidx.compose.foundation.lazy.LazyColumn
import androidx.compose.foundation.lazy.items
import androidx.compose.material.icons.Icons
import androidx.compose.material.icons.filled.ArrowBack
import androidx.compose.material3.*
import androidx.compose.runtime.*
import androidx.compose.ui.Modifier
import androidx.compose.ui.unit.dp
import androidx.navigation.NavController
import com.fiap.softtekapp.data.model.PerguntaDto
import com.fiap.softtekapp.data.model.RespostaRequest
import com.fiap.softtekapp.data.network.RetrofitInstance
import kotlinx.coroutines.launch

@OptIn(ExperimentalMaterial3Api::class)
@Composable
fun PerguntaListScreen(
    avaliacaoCodigo: String,
    blocoCodigo: String,
    navController: NavController
) {
    var perguntas by remember { mutableStateOf<List<PerguntaDto>>(emptyList()) }
    val respostas = remember { mutableStateMapOf<String, String>() }
    var loading by remember { mutableStateOf(true) }
    var error by remember { mutableStateOf<String?>(null) }
    var sucesso by remember { mutableStateOf(false) }
    val scope = rememberCoroutineScope()

    LaunchedEffect(Unit) {
        scope.launch {
            try {
                perguntas = RetrofitInstance.api.obterPerguntas(avaliacaoCodigo, blocoCodigo)
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
                title = { Text("Perguntas do Bloco") },
                navigationIcon = {
                    IconButton(onClick = { navController.popBackStack() }) {
                        Icon(Icons.Default.ArrowBack, contentDescription = "Voltar")
                    }
                }
            )
        }
    ) { padding ->
        Column(
            modifier = Modifier
                .padding(padding)
                .padding(16.dp)
                .fillMaxSize()
        ) {
            if (loading) {
                CircularProgressIndicator()
            } else if (error != null) {
                Text("Erro: $error", color = MaterialTheme.colorScheme.error)
            } else if (sucesso) {
                Text("Respostas enviadas com sucesso!", color = MaterialTheme.colorScheme.primary)
            } else {
                LazyColumn {
                    items(perguntas) { pergunta ->
                        Column(modifier = Modifier.padding(vertical = 8.dp)) {
                            Text(pergunta.descricao, style = MaterialTheme.typography.titleMedium)
                            pergunta.valoresAceitos.forEach { valor ->
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
                }

                Spacer(modifier = Modifier.height(16.dp))

                Button(onClick = {
                    scope.launch {
                        try {
                            perguntas.forEach { pergunta ->
                                val escalaId = respostas[pergunta.codigo]
                                if (escalaId != null) {
                                    RetrofitInstance.api.enviarResposta(
                                        RespostaRequest(pergunta.codigo, escalaId)
                                    )
                                }
                            }
                            sucesso = true
                        } catch (e: Exception) {
                            error = e.localizedMessage
                        }
                    }
                }) {
                    Text("Enviar Respostas")
                }
            }
        }
    }
}
