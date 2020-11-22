using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsuarioService.Services;

namespace UsuarioService.Validacao.CPF
{
    public class CpfValidador : ICpfValidador
    {
        private string _value;
        static readonly int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        static readonly int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        private readonly IUsuarioManager _usuarioManager;

        public CpfValidador(IUsuarioManager usuarioManager) 
        {
            _usuarioManager = usuarioManager;
        }

        public void ValidaCpf(string value, int id = 0)
        {
            AtribuiCpf(value);
            VerificaSeNumeroContemLetras();
            CalculaNumeroDeDigitos();
            VerficarSeTodosOsDigitosSaoIdenticos();
            VerificaSeCpfEValido();
            ExisteCPF(id);            
        }

        public void ExisteCPF(int id)
        {
            if (id == 0)
            {
                var existeUsuarioComCPF = _usuarioManager.BuscaPorCPF(_value);

                if (existeUsuarioComCPF)
                {
                    throw new Exception("Já existe um Usuário com o CPF informado.");
                }
            }         
        }

        public void AtribuiCpf(string value)
        {
            _value = value;
        }

        #region Validações

        private void VerificaSeNumeroContemLetras()
        {
            if (_value.Where(c => char.IsLetter(c)).Count() > 0)
            {
                throw new Exception("O CPF não pode conter letras alfabéticas.");
            }
        }

        private void CalculaNumeroDeDigitos()
        {
            var result = 0;
            for (var i = 0; i < _value.Length; i++)
            {
                if (char.IsDigit(_value[i]))
                {
                    result++;
                }
            }

            if (result != 11)
            {
                throw new Exception("O CPF não pode ter menos ou mais de 11 digitos.");
            }
        }

        private void VerficarSeTodosOsDigitosSaoIdenticos()
        {
            var previous = -1;

            for (var i = 0; i < _value.Length; i++)
            {
                if (char.IsDigit(_value[i]))
                {
                    var digito = _value[i];
                    if (previous == -1)
                    {
                        previous = digito;
                    }
                    else
                    {
                        if (previous != digito)
                        {
                            return;
                        }
                    }
                }
            }
            throw new Exception("CPF inválido, não pode possuir todos os números idênticos.");
        }

        private int ObterDigito(int posicao)
        {
            int count = 0;
            for (int i = 0; i < _value.Length; i++)
            {
                if (char.IsDigit(_value[i]))
                {
                    if (count == posicao)
                    {
                        return _value[i] - '0';
                    }
                    count++;
                }
            }
            return 0;
        }

        private void VerificaSeCpfEValido()
        {
            int totalDigitoI = 0;
            int totalDigitoII = 0;

            for (int posicao = 0; posicao < 9; posicao++)
            {
                var digito = ObterDigito(posicao);
                totalDigitoI += digito * (10 - posicao);
                totalDigitoII += digito * (11 - posicao);
            }

            var modI = totalDigitoI % 11;

            if (modI < 2)
                modI = 0;
            else
                modI = 11 - modI;

            totalDigitoII += modI * 2;
            var modII = totalDigitoII % 11;

            if (modII < 2)
                modII = 0;
            else
                modII = 11 - modII;

            if (ObterDigito(9) != modI || ObterDigito(10) != modII)
            {
                throw new Exception("CPF incorreto, não possui os dígitos verificadores válidos.");
            }
        }
        #endregion
    }
}
