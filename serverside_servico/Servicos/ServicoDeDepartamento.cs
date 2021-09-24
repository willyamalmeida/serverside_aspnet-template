using System;
using System.Linq.Expressions;
using serverside_servico.Dtos;
using serverside_servico.Infraestrutura.Conversores;
using serverside_servico.Infraestrutura.Dtos;
using serverside_servico.Infraestrutura.Servicos;
using serverside_servico.Interfaces.Repositorios;
using serverside_servico.Interfaces.Servicos;
using serverside_servico.Negocio;

namespace serverside_servico.Servicos
{
    public class ServicoDeDepartamento : ServicoComCodigoNumerico<DtoDepartamento, Departamento>, IServicoDeDepartamento
    {
        public ServicoDeDepartamento(IRepositorioDepartamento repositorio, IConversorComCodigoNumerico<DtoDepartamento, Departamento> conversor)
            : base(repositorio, conversor)
        {
        }

        public override DtoPaginado<DtoDepartamento> ConsulteParcial(string filtro, int pagina, int quantidade)
        {
            var resultado = ((IRepositorioDepartamento)Repositorio).ConsulteParcial(
                filtro,
                pagina,
                quantidade,
                ObtenhaExpressao);

            var conversorDepartamento = (IConversorComCodigoNumerico<DtoDepartamento, Departamento>)Conversor;
            var conversorPaginado = new ConversorPaginado<DtoDepartamento, Departamento>(conversorDepartamento);

            var dtoPaginado = conversorPaginado.ConvertaParaDto(resultado);

            return dtoPaginado;
        }

        public override DtoPaginado<DtoDepartamento> ConsultePaginado(string filtro, int pagina, int quantidade)
        {
            var resultado = ((IRepositorioDepartamento)Repositorio).ConsultePaginada(pagina, quantidade);

            var conversorFuncionario = (IConversorComCodigoNumerico<DtoDepartamento, Departamento>)Conversor;
            var conversorPaginado = new ConversorPaginado<DtoDepartamento, Departamento>(conversorFuncionario);

            var dtoPaginado = conversorPaginado.ConvertaParaDto(resultado);

            return dtoPaginado;
        }

        private Expression<Func<Departamento, bool>> ObtenhaExpressao(string filtro)
        {
            if (int.TryParse(filtro, out int codigo))
            {
                return x => x.Codigo == codigo;
            }

            return x => x.Descricao.ToUpperInvariant().StartsWith(filtro);
        }
    }
}
