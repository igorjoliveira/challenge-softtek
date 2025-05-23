package com.fiap.softtekapp

import android.os.Bundle
import androidx.activity.ComponentActivity
import androidx.activity.compose.setContent
import androidx.activity.enableEdgeToEdge
import androidx.compose.material3.MaterialTheme
import androidx.compose.material3.Surface
import androidx.compose.runtime.Composable
import androidx.navigation.NavType
import androidx.navigation.compose.*
import androidx.navigation.navArgument
import com.fiap.softtekapp.ui.AssistenciaListScreen
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
fun AppNavigation() {
    val navController = rememberNavController()

    NavHost(
        navController = navController,
        startDestination = "assistencias"
    ) {
        composable("assistencias") {
            AssistenciaListScreen(navController)
        }
        composable(
            route = "main/{codigo}",
            arguments = listOf(navArgument("codigo") { type = NavType.StringType })
        ) { backStackEntry ->
            val codigo = backStackEntry.arguments?.getString("codigo") ?: ""
            MainScreen(codigo)
        }
    }
}
