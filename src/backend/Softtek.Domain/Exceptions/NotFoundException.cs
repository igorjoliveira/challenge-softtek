﻿namespace Softtek.Domain.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string mensagem) : base(mensagem)
        {
        }
    }
}
