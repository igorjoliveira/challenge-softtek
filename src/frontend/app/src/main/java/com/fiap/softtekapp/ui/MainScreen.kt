package com.fiap.softtekapp.ui

import androidx.compose.foundation.layout.*
import androidx.compose.foundation.lazy.LazyColumn
import androidx.compose.foundation.lazy.items
import androidx.compose.material.icons.Icons
import androidx.compose.material.icons.filled.ArrowBack
import androidx.compose.material3.*
import androidx.compose.runtime.*
import androidx.compose.ui.Alignment
import androidx.compose.ui.Modifier
import androidx.compose.ui.unit.dp
import androidx.lifecycle.viewmodel.compose.viewModel
import androidx.navigation.NavController
import com.fiap.softtekapp.data.network.RetrofitInstance
import kotlinx.coroutines.launch

@OptIn(ExperimentalMaterial3Api::class)
@Composable
fun MainScreen(codigo: String, navController: NavController) {
    val viewModel = remember { MainViewModel(codigo) }
    val apoios by viewModel.apoios.collectAsState()
    val loading by viewModel.loading.collectAsState()
    val error by viewModel.error.collectAsState()

    LaunchedEffect(Unit) {
        viewModel.carregarAssistencia();
    }

    Scaffold(
        topBar = {
            CenterAlignedTopAppBar(
                title = { Text("Assistência Emocional") },
                navigationIcon = {
                    IconButton(onClick = { navController.popBackStack() }) {
                        Icon(Icons.Default.ArrowBack, contentDescription = "Voltar")
                    }
                }
            )
        },
        content = { padding ->
            Column(
                modifier = Modifier
                    .padding(padding)
                    .padding(16.dp)
                    .fillMaxSize(),
                verticalArrangement = Arrangement.Top,
                horizontalAlignment = Alignment.CenterHorizontally
            ) {
                if (loading) {
                    CircularProgressIndicator()
                } else if (error != null) {
                    Text("Erro: $error", color = MaterialTheme.colorScheme.error)
                } else {
                    LazyColumn {
                        items(apoios) { apoio ->
                            Card(
                                modifier = Modifier
                                    .fillMaxWidth()
                                    .padding(vertical = 4.dp)
                            ) {
                                Column(modifier = Modifier.padding(16.dp)) {
                                    Text("Título: ${apoio.titulo}")
                                    Text("Tipo: ${apoio.tipo}")
                                    Text("Descrição: ${apoio.descricao ?: "Sem descrição"}")
                                    Text("Data: ${apoio.dataCriacao}")
                                }
                            }
                        }
                    }
                }
            }
        }
    )
}
