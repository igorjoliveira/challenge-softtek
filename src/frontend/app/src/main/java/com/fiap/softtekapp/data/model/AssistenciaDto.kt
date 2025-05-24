package com.fiap.softtekapp.data.model

import com.google.gson.annotations.SerializedName

data class AssistenciaDto(
    @SerializedName("codigo") val codigo: String,
    @SerializedName("apoios") val apoios: List<ApoioDto>
)