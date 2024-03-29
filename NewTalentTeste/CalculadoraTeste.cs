using NewTalent.services;

namespace NewTalentTeste;

public class CalculadoraTeste
{
    public Calculadora ConstruirClasse()
    {
        string data = "29/03/2024";
        Calculadora calc = new Calculadora(data);
        return calc;
    }

    [Theory]
    [InlineData (1, 2, 3)]
    [InlineData (4, 5, 9)]
    public void TesteSomar(int num1, int num2, int resultado)
    {
        Calculadora calc = ConstruirClasse();
        int resultadoCalculadora = calc.Somar(num1, num2);

        Assert.Equal(resultado, resultadoCalculadora);
    }

    [Theory]
    [InlineData (10, 2, 8)]
    [InlineData (14, 5, 9)]

    public void TesteSubtrair(int num1, int num2, int resultado)
    {
        Calculadora calc = ConstruirClasse();
        int resultadoCalculadora = calc.Subtrair(num1, num2);

        Assert.Equal(resultado, resultadoCalculadora);
    }

    [Theory]
    [InlineData (1, 2, 2)]
    [InlineData (4, 5, 20)]
    public void TesteMultiplicar(int num1, int num2, int resultado)
    {
        Calculadora calc = ConstruirClasse();
        int resultadoCalculadora = calc.Multiplicar(num1, num2);

        Assert.Equal(resultado, resultadoCalculadora);
    }

    [Theory]
    [InlineData (4, 2, 2)]
    [InlineData (100, 5, 20)]
    public void TesteDividir(int num1, int num2, int resultado)
    {
        Calculadora calc = ConstruirClasse();
        int resultadoCalculadora = calc.Dividir(num1, num2);

        Assert.Equal(resultado, resultadoCalculadora);
    }

    [Fact]
    public void TestarDividaoPorZero()
    {
        Calculadora calc = ConstruirClasse();

        Assert.Throws<DivideByZeroException>(() => calc.Dividir(3,0));
    }

    [Fact]
    public void TestarHistorico()
    {
        Calculadora calc = ConstruirClasse();
        calc.Somar(1, 2);
        calc.Somar(2, 6);
        calc.Somar(16, 18);
        calc.Somar(4, 20);

        var lista = calc.Historico();

        Assert.NotEmpty(calc.Historico());
        Assert.Equal(3, lista.Count);
    }
}