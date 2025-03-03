using System.ComponentModel;

namespace SistemadeTarefa.Enums;

public enum StatusTarefa
{
    [Description("A fazer")]
    AFazer = 1,
    [Description("Em andamento")]
    EmAndamento = 2,
    [Description("Concluída")]
    Concluida = 3
}
