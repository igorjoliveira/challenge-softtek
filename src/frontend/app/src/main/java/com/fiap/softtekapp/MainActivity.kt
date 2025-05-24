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
import com.fiap.softtekapp.ui.CheckinScreen
import com.fiap.softtekapp.ui.HomeScreen
import com.fiap.softtekapp.ui.MainScreen
import com.fiap.softtekapp.ui.PerguntaListScreen
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

    NavHost(navController = navController, startDestination = "home") {
        composable("home") {
            HomeScreen(navController)
        }
        composable("assistencias") {
            AssistenciaListScreen(navController)
        }
        composable("avaliacoes") {
            AvaliacaoListScreen(navController)
        }
        composable(
            route = "main/{codigo}",
            arguments = listOf(navArgument("codigo") { type = NavType.StringType })
        ) { backStackEntry ->
            val codigo = backStackEntry.arguments?.getString("codigo") ?: ""
            MainScreen(codigo, navController)
        }
        composable(
            route = "blocos/{avaliacaoCodigo}",
            arguments = listOf(navArgument("avaliacaoCodigo") { type = NavType.StringType })
        ) { backStackEntry ->
            val codigo = backStackEntry.arguments?.getString("avaliacaoCodigo") ?: ""
            BlocoListScreen(codigo, navController)
        }
        composable("checkin") {
            CheckinScreen(navController)
        }
        composable(
            "perguntas/{avaliacaoCodigo}/{blocoCodigo}",
            arguments = listOf(
                navArgument("avaliacaoCodigo") { type = NavType.StringType },
                navArgument("blocoCodigo") { type = NavType.StringType }
            )
        ) {
            val avaliacaoId = it.arguments?.getString("avaliacaoCodigo") ?: ""
            val blocoId = it.arguments?.getString("blocoCodigo") ?: ""
            PerguntaListScreen(avaliacaoId, blocoId, navController)
        }
    }
}
