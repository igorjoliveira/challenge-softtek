package com.fiap.softtekapp.data.model

import com.fiap.softtekapp.data.model.EscalaValorDto

data class PerguntaDto(
    val codigo: String,
    val descricao: String,
    val desativado: Boolean,
    val escalaCodigo: String,
    val escalaDescricao: String,
    val valoresAceitos: List<EscalaValorDto>
)