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
import com.fiap.softtekapp.data.model.BlocoDto
import com.fiap.softtekapp.data.network.RetrofitInstance
import kotlinx.coroutines.launch

@OptIn(ExperimentalMaterial3Api::class)
@Composable
fun BlocoListScreen(avaliacaoCodigo: String, navController: NavController) {
    var blocos by remember { mutableStateOf<List<BlocoDto>>(emptyList()) }
    var loading by remember { mutableStateOf(true) }
    var error by remember { mutableStateOf<String?>(null) }
    val scope = rememberCoroutineScope()

    LaunchedEffect(Unit) {
        scope.launch {
            try {
                blocos = RetrofitInstance.api.obterBlocosPorAvaliacao(avaliacaoCodigo)
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
                title = { Text("Blocos da Avaliação") },
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
            } else {
                LazyColumn {
                    items(blocos) { bloco ->
                        Card(
                            modifier = Modifier
                                .fillMaxWidth()
                                .padding(vertical = 4.dp)
                                .clickable {
                                    navController.navigate("perguntas/$avaliacaoCodigo/${bloco.codigo}")
                                }
                        ) {
                            Column(modifier = Modifier.padding(16.dp)) {
                                Text("Título: ${bloco.titulo}")
                                Text("Frequência: ${bloco.frequencia}")
                            }
                        }
                    }
                }
            }
        }
    }
}
