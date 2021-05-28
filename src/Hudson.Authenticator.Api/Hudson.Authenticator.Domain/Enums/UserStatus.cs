using System;
using System.ComponentModel;

namespace Hudson.Authenticator.Domain.Enums
{
    public enum UserStatus
    {
        NaoInformado = 0,

        [Description("Ativo")]
        Ativo = 1,

        [Description("Bloqueado")]
        Bloqueado = 2,

        [Description("Excluído")]
        Excluido = 8,

        [Description("Inativo")]
        Inativo = 9,
    }

    public enum StatusLogado : Int16
    {
        [Description("Ativo")]
        Ativo = 1,
        [Description("Logout")]
        Logout = 0
    }
}
