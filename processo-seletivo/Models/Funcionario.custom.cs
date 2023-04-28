namespace processo_seletivo.Models
{
    /// <summary>
    /// Código customizado (não gerado pelo Entity Framework) para a tabela de Funcionarios
    /// </summary>
    public partial class Funcionario
    {
        /// <summary>
        /// Retorna a lista de todos os funcionarios cadastrados.
        /// </summary>
        /// <returns></returns>
        public static List<Funcionario> GetTodos()
        {
            using (var bd = new ProcessoseletivoContext())
            {
                var dados = bd.Funcionarios.ToList();
                return dados;
            }
        }

        /// <summary>
        /// Cadastra um novo funcionário.
        /// </summary>
        /// <param name="novoFuncionario">Dados do funcionário a cadastrar</param>
        /// <returns>Objeto "novoFuncionario" com a propriedade "id" preenchida com o valor gerado no BD</returns>
        public static Funcionario Inclui(Funcionario novoFuncionario)
        {
            using (var bd = new ProcessoseletivoContext())
            {
                bd.Funcionarios.Add(novoFuncionario);
                bd.SaveChanges();
                return novoFuncionario;
            }
        }
    }
}
