using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity.Infrastructure.Interception;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace WebAuditInterception.Models
{
    public class AuditInterceptor : IDbCommandInterceptor
    {
        private AuditDBContext db = new AuditDBContext();

        private string[] _tables;

        public AuditInterceptor(params string[] tables)
        {
            _tables = tables;
        }

        public void NonQueryExecuted(DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
        {
            /*Console.WriteLine(command.CommandText);
            
            
            foreach (DbParameter item in command.Parameters)
            {
                Console.WriteLine(item.ParameterName);
                Console.WriteLine(item.Value);
            */
        }

        public void NonQueryExecuting(DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
        {
            GravarComando(command);
        }

        public void ReaderExecuted(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
        {
            //Console.WriteLine(command.CommandText);
        }

        public void ReaderExecuting(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
        {
            GravarComando(command);
        }

        public void ScalarExecuted(DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
        {
            //Console.WriteLine(command.CommandText);
        }

        public void ScalarExecuting(DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
        {
            GravarComando(command);
        }

        private void GravarComando(DbCommand command)
        {
            var sql = command.CommandText;
            bool podeExecutar =
                (sql.ToLower().IndexOf("comando") < 0)
                && (sql.ToLower().IndexOf("parametro") < 0);
                      
            if (podeExecutar)
            {
                var comando = new Comando();
                comando.Texto = command.CommandText;
                switch (command.CommandType)
                {
                    case System.Data.CommandType.Text:
                        comando.Tipo = 1;
                        break;
                    case System.Data.CommandType.StoredProcedure:
                        comando.Tipo = 4;
                        break;
                    case System.Data.CommandType.TableDirect:
                        comando.Tipo = 512;
                        break;
                    default:
                        break;
                }

                db.Comandos.Add(comando);

                foreach (DbParameter item in command.Parameters)
                {
                    var parametro = new Parametro();
                    
                    parametro.Nome = item.ParameterName;
                    switch (item.Direction)
                    {
                        case System.Data.ParameterDirection.Input:
                            parametro.Direcao = 1;
                            break;
                        case System.Data.ParameterDirection.Output:
                            parametro.Direcao = 2;
                            break;
                        case System.Data.ParameterDirection.InputOutput:
                            parametro.Direcao = 3;
                            break;
                        case System.Data.ParameterDirection.ReturnValue:
                            parametro.Direcao = 6;
                            break;
                        default:
                            break;
                    }

                    parametro.ValorText = item.Value.ToString();

                    if (IsNumber(item.Value))
                    {
                        parametro.ValorNumero = Convert.ToDouble(item.Value);
                    }

                    parametro.ComandoInfo = comando;

                    db.Parametros.Add(parametro);
                }

                db.SaveChanges();                               

            }

        }


        public bool IsNumber(object value)
        {
            return value is sbyte
                    || value is byte
                    || value is short
                    || value is ushort
                    || value is int
                    || value is uint
                    || value is long
                    || value is ulong
                    || value is float
                    || value is double
                    || value is decimal;
        }
    }
}