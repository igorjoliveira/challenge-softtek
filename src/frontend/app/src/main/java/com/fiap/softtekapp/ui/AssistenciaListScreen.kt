package com.fiap.softtekapp.ui

import androidx.compose.foundation.clickable
import androidx.compose.foundation.layout.*
import androidx.compose.foundation.lazy.LazyColumn
import androidx.compose.foundation.lazy.items
import androidx.compose.material3.*
import androidx.compose.runtime.*
import androidx.compose.ui.Modifier
import androidx.compose.ui.unit.dp
import androidx.navigation.NavController
import com.fiap.softtekapp.data.model.AssistenciaResumoDto
import com.fiap.softtekapp.data.network.RetrofitInstance
import kotlinx.coroutines.launch

@OptIn(ExperimentalMaterial3Api::class)
@Composable
fun AssistenciaListScreen(navController: NavController) {
    var assistencias by remember { mutableStateOf<List<AssistenciaResumoDto>>(emptyList()) }
    var loading by remember { mutableStateOf(true) }
    var error by remember { mutableStateOf<String?>(null) }
    val scope = rememberCoroutineScope()

    LaunchedEffect(Unit) {
        scope.launch {
            try {
                assistencias = RetrofitInstance.api.listarAssistencias()
            } catch (e: Exception) {
                error = e.localizedMessage ?: "Erro ao carregar assistências"
            } finally {
                loading = false
            }
        }
    }

    Scaffold(
        topBar = {
            CenterAlignedTopAppBar(
                title = { Text("Selecione uma Assistência") }
            )
        }
    ) { padding ->
        Column(
            modifier = Modifier
                .padding(padding)
                .padding(16.dp)
                .fillMaxSize(),
            verticalArrangement = Arrangement.Top
        ) {
            if (loading) {
                CircularProgressIndicator()
            } else if (error != null) {
                Text("Erro: $error", color = MaterialTheme.colorScheme.error)
            } else {
                LazyColumn {
                    items(assistencias) { assistencia ->
                        Card(
                            modifier = Modifier
                                .fillMaxWidth()
                                .padding(vertical = 4.dp)
                                .clickable {
                                    navController.navigate("main/${assistencia.codigo}")
                                }
                        ) {
                            Column(modifier = Modifier.padding(16.dp)) {
                                Text("Código: ${assistencia.codigo}")
                            }
                        }
                    }
                }
            }
        }
    }
}
