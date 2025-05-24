package com.fiap.softtekapp.data.network

import com.fiap.softtekapp.data.model.*
import retrofit2.http.Body
import retrofit2.http.GET
import retrofit2.http.POST
import retrofit2.http.Path

interface ApiService {

    @GET("api/assistencia/{codigo}")
    suspend fun obterAssistencia(
        @Path("codigo") codigo: String
    ): AssistenciaDto

    @GET("api/assistencia")
    suspend fun listarAssistencias(): List<AssistenciaResumoDto>

    @GET("api/registro/avaliacoes")
    suspend fun listarAvaliacoes(): List<AvaliacaoResumoDto>

    @GET("api/registro/{avaliacaoCodigo}/blocos")
    suspend fun obterBlocos(@Path("avaliacaoCodigo") codigo: String): List<BlocoDto>

}