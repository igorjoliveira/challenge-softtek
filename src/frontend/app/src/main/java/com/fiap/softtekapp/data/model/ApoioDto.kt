package com.fiap.softtekapp.data.model

import com.google.gson.annotations.SerializedName

data class ApoioDto(
    @SerializedName("codigo") val codigo: String,
    @SerializedName("titulo") val titulo: String,
    @SerializedName("descricao") val descricao: String?,
    @SerializedName("tipo") val tipo: String,
    @SerializedName("dataCriacao") val dataCriacao: String
)