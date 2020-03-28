﻿using System;

namespace Caelum.Banco.Negocio
{
    public abstract class Conta
    {
        private static int totalContas;

        public Conta(string titular)
        {
            Titular = new Cliente(titular);
            Conta.totalContas++;
            Numero = Conta.totalContas;
        }

        public static int ProximoNumero => totalContas + 1;
        public int Numero { get; }
        public Cliente Titular { get; }
        public double Saldo { get; private set; }


        public virtual void Saca(double valor)
        {
            if (valor < 0) throw new ArgumentException("Saque com valor inválido (esperado: valor maior que zero)");
            if (Saldo < valor) throw new SaldoInsuficienteException(valor, Saldo);
            Saldo -= valor;
        }

        public virtual void Deposita(double valor)
        {
            if (valor < 0) throw new ArgumentException("Depósito com valor inválido (esperado: valor maior que zero)");
            Saldo += valor;
        }

        public virtual void Transfere(double valor, Conta destino)
        {
            this.Saca(valor);
            destino.Deposita(valor);
        }

        public override string ToString()
        {
            return $"{this.Numero:000} - {this.Titular.Nome}";
        }

    }
}
