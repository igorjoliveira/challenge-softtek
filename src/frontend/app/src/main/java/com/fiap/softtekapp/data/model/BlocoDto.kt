
package com.fiap.softtekapp.data.model

data class BlocoDto(
    val codigo: String,
    val titulo: String,
    val frequencia: FrequenciaDto,
    var perguntas: List<PerguntaDto> = emptyList()
)



