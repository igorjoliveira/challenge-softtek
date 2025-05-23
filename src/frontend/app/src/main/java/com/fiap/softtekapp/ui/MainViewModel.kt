package com.fiap.softtekapp.ui

import androidx.lifecycle.ViewModel
import androidx.lifecycle.viewModelScope
import com.fiap.softtekapp.data.model.ApoioDto
import com.fiap.softtekapp.data.network.RetrofitInstance
import kotlinx.coroutines.flow.MutableStateFlow
import kotlinx.coroutines.flow.StateFlow
import kotlinx.coroutines.launch

class MainViewModel (private val codigo: String) : ViewModel() {

    private val _apoios = MutableStateFlow<List<ApoioDto>>(emptyList())
    val apoios: StateFlow<List<ApoioDto>> = _apoios

    private val _loading = MutableStateFlow(false)
    val loading: StateFlow<Boolean> = _loading

    private val _error = MutableStateFlow<String?>(null)
    val error: StateFlow<String?> = _error

    fun carregarAssistencia() {
        viewModelScope.launch {
            _loading.value = true
            _error.value = null

            try {
                val response = RetrofitInstance.api.obterAssistencia(codigo)
                _apoios.value = response.apoios
            } catch (e: Exception) {
                _error.value = e.localizedMessage ?: "Erro desconhecido"
            } finally {
                _loading.value = false
            }
        }
    }
}
