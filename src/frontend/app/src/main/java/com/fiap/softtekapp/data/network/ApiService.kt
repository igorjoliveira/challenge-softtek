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

    @POST("api/avaliacao/resposta")
    suspend fun enviarResposta(@Body resposta: RespostaRequest)

    @GET("api/registro/avaliacoes/{codigo}/blocos")
    suspend fun obterBlocosPorAvaliacao(@Path("codigo") codigo: String): List<BlocoDto>

    @GET("api/registro/avaliacoes/{avaliacaoCodigo}/blocos/{blocoCodigo}/perguntas")
    suspend fun obterPerguntas(
        @Path("avaliacaoCodigo") avaliacaoId: String,
        @Path("blocoCodigo") blocoId: String
    ): List<PerguntaDto>

    @POST("api/Avaliacao/questionarios/{data}/respostas")
    suspend fun enviarRespostas(
        @Path("data") data: String,
        @Body payload: RespostaFinalDto
    )

}