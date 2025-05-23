package com.fiap.softtekapp.data.network

import com.fiap.softtekapp.data.model.*
import retrofit2.http.GET
import retrofit2.http.Path

interface ApiService {

    @GET("api/assistencia/{codigo}")
    suspend fun obterAssistencia(
        @Path("codigo") codigo: String
    ): AssistenciaResponse

    @GET("api/assistencia")
    suspend fun listarAssistencias(): List<AssistenciaResumoDto>

}

// Resposta da API contendo a lista de apoios
data class AssistenciaResponse(
    val codigo: String,
    val apoios: List<ApoioDto>
)