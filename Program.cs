using System;

namespace Revisao
{
    class Program
    {
        static void Main(string[] args)
        {
            Aluno[] alunos = new Aluno[5];
            int i=0;
            string opcusuario = OpcaooUsuario();

            while (opcusuario.ToUpper() != "X")
            {
                switch (opcusuario)
                {
                    case "1":
                        //inserir aluno
                        Console.WriteLine("Digite o nome do aluno:");
                        Aluno aluno = new Aluno();
                        aluno.Nome = Console.ReadLine();

                        Console.WriteLine("Digite a nota do aluno:");
                        if(decimal.TryParse(Console.ReadLine(),out decimal nota)){
                            aluno.Nota = nota;
                        }else{
                            throw new ArgumentNullException("Valor da nota NULL");
                        }
                        alunos[i]= aluno;
                        i++;
                        break;
                    case "2":
                        //listar aluno
                        foreach(var a in alunos){
                            if(!string.IsNullOrEmpty(a.Nome)){
                            Console.WriteLine("Nome do aluno: "+a.Nome+" Nota: "+a.Nota);
                            }
                        }
                        break;
                    case "3":
                        // calcular media
                        decimal media=0,mg;
                        int v=0,x;
                        for (x = 0; x < alunos.Length; x++)
                        {
                            if(!string.IsNullOrEmpty(alunos[x].Nome)){
                            media = media + alunos[x].Nota;
                            v++;
                            }
                        }
                        mg = media/v;
                        Conseitos coGeral = Conseitos.F;
                        if(mg < 3){
                            coGeral = Conseitos.F;
                        }else if(mg >=3 && mg <6){
                            coGeral = Conseitos.D;
                        }else if(mg >=6 && mg <8){
                            coGeral = Conseitos.C;
                        }else if(mg >=8 && mg <=9){
                            coGeral = Conseitos.B;
                        }else if(mg >9){
                            coGeral = Conseitos.A;
                        }
                        Console.WriteLine("A media da nota dos alunos: "+media/v+" Conseito: "+ coGeral);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                    //break;
                }

               
                opcusuario = OpcaooUsuario();
            }

        }

        private static string OpcaooUsuario()
        {
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("1 - Inserir aluno");
            Console.WriteLine("2 - Mostra alunos");
            Console.WriteLine("3 - Calcular media");
            Console.WriteLine("x - Sair");
            string opcusuario = Console.ReadLine();
            return opcusuario;
        }
    }
}
