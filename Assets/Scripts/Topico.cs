using System.Collections;
using System.Collections.Generic;

public class Topico
{
    public string nome;
    public string descricao;
    public List<int> minigames;

    public Topico(string nome, string descricao, List<int> minigames)
    {
        this.nome = nome;
        this.descricao = descricao;
        this.minigames = minigames;
    }
}
