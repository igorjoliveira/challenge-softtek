package com.fiap.softtekapp

import android.os.Bundle
import androidx.activity.ComponentActivity
import androidx.activity.compose.setContent
import androidx.activity.enableEdgeToEdge
import androidx.compose.material3.MaterialTheme
import androidx.compose.material3.Surface
import androidx.compose.runtime.Composable
import androidx.compose.ui.Modifier
import androidx.navigation.NavType
import androidx.navigation.compose.*
import androidx.navigation.navArgument
import com.fiap.softtekapp.ui.AssistenciaListScreen
import com.fiap.softtekapp.ui.AvaliacaoListScreen
import com.fiap.softtekapp.ui.BlocoListScreen
import com.fiap.softtekapp.ui.MainScreen
import com.fiap.softtekapp.ui.theme.SofttekappTheme

class MainActivity : ComponentActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        enableEdgeToEdge()
        setContent {
            SofttekappTheme {
                Surface(color = MaterialTheme.colorScheme.background) {
                    AppNavigation()
                }
            }
        }
    }
}

@Composable
fun AppNavigation(modifier: Modifier = Modifier) {
    val navController = rememberNavController()

    NavHost(navController = navController, startDestination = "assistencias") {
        composable("assistencias") {
            AssistenciaListScreen(navController)
        }
        composable(
            route = "main/{codigo}",
            arguments = listOf(navArgument("codigo") { type = NavType.StringType })
        ) { backStackEntry ->
            val codigo = backStackEntry.arguments?.getString("codigo") ?: ""
            MainScreen(codigo, navController)
        }
        composable("avaliacoes") {
            AvaliacaoListScreen(navController)
        }
        composable(
            route = "blocos/{avaliacaoCodigo}",
            arguments = listOf(navArgument("avaliacaoCodigo") { type = NavType.StringType })
        ) { backStackEntry ->
            val codigo = backStackEntry.arguments?.getString("avaliacaoCodigo") ?: ""
            BlocoListScreen(codigo, navController)
        }
    }
}
