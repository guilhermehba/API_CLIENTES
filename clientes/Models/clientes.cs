using System;

namespace clientes
    {
        public class clientes
        {
            public int Id { get; private set; }
            public string Nome { get; private set; }
            public DateTime DataNascimento { get; private set; }
            public string CPF { get; private set; }
            public int Salario { get; private set; }
            public string Sexo { get; private set; }

            public clientes(int id, string nome, DateTime dataNascimento, string cpf, int salario, string sexo)
            {
                Id = id;
                Nome = nome;
                DataNascimento = dataNascimento;
                CPF = cpf;
                Salario = salario;
                Sexo = sexo;
        }
    }
}
