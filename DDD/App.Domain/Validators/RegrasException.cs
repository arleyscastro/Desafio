using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace App.Domain.Validators
{
    public class RegrasException: Exception
    {
        protected IList<ViolacaoDeRegra> _erros = new List<ViolacaoDeRegra>();
        private readonly Expression<Func<object, object>> _objeto = x => x;

        public IEnumerable<ViolacaoDeRegra> Erros { get { return _erros; } }

        internal void AdicionarErroAoModelo(string mensagem)
        {
            _erros.Add(new ViolacaoDeRegra { Propriedade = _objeto, Mensagem = mensagem });
        }
    }

    public class RegrasException<TModelo> : RegrasException
    {
        internal void AdicionarErroPara<TPropriedade>(Expression<Func<TModelo, TPropriedade>> propriedade, string mensagem)
        {
            _erros.Add(new ViolacaoDeRegra { Propriedade = propriedade, Mensagem = mensagem });
        }
    }
}
