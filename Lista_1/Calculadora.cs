/*Exercício 1 - Calculadora
Objetivo: usando uma aplicação do tipo console do dotnet, criar uma calculadora simples
que terá as operações de soma, subtração, multiplicação e divisão. Faça o controle de
versionamento da sua aplicação com git e suba a mesma para o github.
Novos conceitos ou funcionalidades desse exercício
Nossa primeira aplicação é bem simples e, se você já tem conhecimentos em lógica de
programação, algoritmos e alguma linguagem de programação não terá problemas para
desenvolver a aplicação. Faremos uso de operadores condicionais, estrutura condicional
'switch', criação e chamada de métodos simples.

Requisitos para desenvolver a aplicação
● Ao entrar na calculadora o usuário deverá ter um menu com as opções 1, 2, 3, 4 e 0.
Sendo elas:
1 - Somar
2 - Subtrair
3 - Multiplicar
4 - Dividir
0 - Sair

● Todas as operações devem solicitar que o usuário entre com dois valores e então
estes valores devem ser utilizados para realizar a operação escolhida. Exemplo de
fluxo da operação de Soma:
i.Aplicação solicita o primeiro valor;
ii.Usuário digita valor e pressiona enter;
iii.Aplicação solicita o segundo valor;
iv.Usuário digita valor e pressiona enter;
v.Aplicação escreve em tela o resultado da soma;
vi.Usuário pressiona Enter;
vii.Aplicação retorna para o menu;

● Para a operação de divisão, validar se o divisor é 0. Se verdadeiro deve ser exibida
a mensagem "Não é possível dividir por zero."
Opcional
● Fazer o controle de versionamento da sua aplicação usando git;
● Subir a aplicação para um repositório do github.

Desafios
1. Crie uma nova opção na calculadora (opção número 5 do menu) que retorne o resto
da divisão.
2. Crie uma nova opção na calculadora (opção número 6 do menu) que retorne o
resultado da potenciação de uma determinada base pelo seu expoente. Exemplo 2³ = 8.*/

using System;

class Program
{
    static void Main()
    {
        bool somar = false, subtrair = false, multiplicar = false, dividir = false, resto = false, potencia = false;
        bool check = false;
        bool voltar = false;

        Console.WriteLine("Bem-vindo à Calculadora :)\n");

        while (true)
        {
            Console.WriteLine(" 1 - Somar");
            Console.WriteLine(" 2 - Subtrair");
            Console.WriteLine(" 3 - Multiplicar");
            Console.WriteLine(" 4 - Dividir");
            Console.WriteLine(" 5 - Resto da divisão");
            Console.WriteLine(" 6 - Potência");
            Console.WriteLine(" 0 - Sair");

            Console.WriteLine("Digite a operação que deseja realizar: ");
            string operacao = Console.ReadLine();
            int operacaoSelecionada;
            bool validOption = int.TryParse(operacao, out operacaoSelecionada);

            while (!validOption || operacaoSelecionada < 0 || operacaoSelecionada > 6)
            {
                Console.WriteLine("Digite uma opção válida: ");
                operacao = Console.ReadLine();
                validOption = int.TryParse(operacao, out operacaoSelecionada);
            }

            switch (operacaoSelecionada)
            {
                case 0:
                    return;
                case 1:
                    somar = true;
                    break;
                case 2:
                    subtrair = true;
                    break;
                case 3:
                    multiplicar = true;
                    break;
                case 4:
                    dividir = true;
                    break;
                case 5:
                    resto = true;
                    break;
                case 6:
                    potencia = true;
                    break;
            }

            while (somar)
            {
                Console.WriteLine("Ok, então vamos somar :D\n");

                int valor1 = GetValor("Digite o primeiro valor: ");
                int valor2 = GetValor("Digite o segundo valor: ");

                int valorFinal = valor1 + valor2;
                Console.WriteLine($"Certo, então a operação fica: {valor1} + {valor2} = {valorFinal}");

                somar = false;
                check = true;
            }

            while (subtrair)
            {
                Console.WriteLine("Ok, então vamos subtrair :D\n");

                int valor1 = GetValor("Digite o primeiro valor: ");
                int valor2 = GetValor("Digite o segundo valor: ");

                int valorFinal = valor1 - valor2;
                Console.WriteLine($"Certo, então a operação fica: {valor1} - {valor2} = {valorFinal}");

                subtrair = false;
                check = true;
            }

            while (multiplicar)
            {
                Console.WriteLine("Ok, então vamos multiplicar :D\n");

                int valor1 = GetValor("Digite o primeiro valor: ");
                int valor2 = GetValor("Digite o segundo valor: ");

                int valorFinal = valor1 * valor2;
                Console.WriteLine($"Certo, então a operação fica: {valor1} * {valor2} = {valorFinal}");

                multiplicar = false;
                check = true;
            }

            while (dividir)
            {
                Console.WriteLine("Ok, então vamos dividir :D\n");

                int valor1 = GetValor("Digite o primeiro valor: ");
                int valor2 = GetValor("Digite o segundo valor: ");

                while (valor2 == 0)
                {
                    Console.WriteLine("O divisor não pode ser 0. Digite um valor diferente de 0: ");
                    valor2 = GetValor("");
                }

                int valorFinal = valor1 / valor2;
                Console.WriteLine($"Certo, então a operação fica: {valor1} / {valor2} = {valorFinal}");

                dividir = false;
                check = true;
            }

            while (resto)
            {
                Console.WriteLine("Ok, então vamos pegar o resto da divisão :D\n");

                int valor1 = GetValor("Digite o primeiro valor: ");
                int valor2 = GetValor("Digite o segundo valor: ");

                while (valor2 == 0)
                {
                    Console.WriteLine("O divisor não pode ser 0. Digite um valor diferente de 0: ");
                    valor2 = GetValor("");
                }

                int valorFinal = valor1 % valor2;
                Console.WriteLine($"Certo, então a operação fica: {valor1} % {valor2} = {valorFinal}");

                resto = false;
                check = true;
            }

            while (potencia)
            {
                Console.WriteLine("Ok, então vamos fazer uma potência :D\n");

                int valor1 = GetValor("Digite a base (primeiro valor): ");
                int valor2 = GetValor("Digite o expoente (segundo valor): ");

                double valorFinal = Math.Pow(valor1, valor2); // Using Math.Pow for power calculation
                Console.WriteLine($"Certo, então a operação fica: {valor1} ^ {valor2} = {valorFinal}");

                potencia = false;
                check = true;
            }

            while (check)
            {
                Console.WriteLine("Aqui está!  \nDeseja realizar outra operação?");
                Console.WriteLine(" 0 - Sim");
                Console.WriteLine(" 1 - Não");

                string checagem = Console.ReadLine();
                int valorCheck;
                validOption = int.TryParse(checagem, out valorCheck);

                while (!validOption || (valorCheck != 0 && valorCheck != 1))
                {
                    Console.WriteLine("Digite uma opção válida: ");
                    checagem = Console.ReadLine();
                    validOption = int.TryParse(checagem, out valorCheck);
                }

                if (valorCheck == 0)
                {
                    voltar = true;
                    break;
                }
                else
                {
                    return;
                }
            }

            if (!voltar) break;
        }
    }

    static int GetValor(string prompt)
    {
        Console.WriteLine(prompt);
        string input = Console.ReadLine();
        int valor;
        while (!int.TryParse(input, out valor))
        {
            Console.WriteLine("Entrada inválida, por favor insira um número válido: ");
            input = Console.ReadLine();
        }
        return valor;
    }
}
