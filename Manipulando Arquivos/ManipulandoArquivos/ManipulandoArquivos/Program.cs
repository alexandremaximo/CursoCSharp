using System.Globalization;
using System.IO;

string path = @"C:\Curso C#\Intermediário\Manipulando Arquivos\source.csv";
string newFile = "summary.csv";
string newPath = @"C:\Curso C#\Intermediário\Manipulando Arquivos\out\";


StreamReader sr = null;
StreamWriter sw = null;

using (sr = File.OpenText(path))
{
    while (!sr.EndOfStream)
    {
        string linha = sr.ReadLine();

        if (linha != null)
        {
            string nome = linha.Substring(0, linha.IndexOf(";"));
            double valor = double.Parse(linha.Substring(linha.IndexOf(";") + 1, linha.Substring(linha.IndexOf(';') + 1).IndexOf(';')), CultureInfo.InvariantCulture);
            int qtd = int.Parse(linha.Substring(linha.LastIndexOf(";") + 1));
            if (!Directory.Exists(newPath))
            {
                Directory.CreateDirectory(newPath);
            }
            using (sw = File.AppendText(newPath + newFile))
            {
                sw.WriteLine(nome + ";" + (valor * qtd).ToString("F2", CultureInfo.InvariantCulture));
            }

        }
    }
}

