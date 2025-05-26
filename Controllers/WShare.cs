using Painel.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Painel.Controllers
{
    [Authorize(AuthenticationSchemes = "auth")]
    public class WShare : Controller
    {
        #region PropriedadesSessao
        public string MsgAviso
        {
            get
            {
                return HttpContext.Session.GetString("msgaviso");
            }
            set
            {
                HttpContext.Session.SetString("msgaviso", value);
            }
        }
        
        public string MsgErro
        {
            get
            {
                return HttpContext.Session.GetString("msgerro");
            }
            set
            {
                HttpContext.Session.SetString("msgerro", value);
            }
        }
        
        public string Msg
        {
            get
            {
                return HttpContext.Session.GetString("msg");
            }
            set
            {
                HttpContext.Session.SetString("msg", value);
            }
        }

        public string TipoMsg
        {
            get
            {
                return HttpContext.Session.GetString("tipomsg");
            }
            set
            {
                HttpContext.Session.SetString("tipomsg", value);
            }
        }

        public string NomePerfil
        {
            get
            {
                return HttpContext.Session.GetString("perfil");
            }
            set
            {
                HttpContext.Session.SetString("perfil", value);
            }
        }

        public int IdPerfil
        {
            get
            {
                return int.Parse(HttpContext.Session.GetString("idperfil"));
            }
            set
            {
                HttpContext.Session.SetString("idperfil", value.ToString());
            }
        }

        public int IdUsuario
        {
            get
            {
                return int.Parse(HttpContext.Session.GetString("idusuario"));
            }
            set
            {
                HttpContext.Session.SetString("idusuario", value.ToString());
            }
        }
   
        public string NomeUsuario
        {
            get
            {
                return HttpContext.Session.GetString("nomeusuario");
            }
            set
            {
                HttpContext.Session.SetString("nomeusuario", value.ToString());
            }
        }

        public void SetRevenda(revendas value)
        {            
            HttpContext.Session.SetString("revenda", JsonConvert.SerializeObject(value));            
        }
        
        public revendas GetRevenda(string key)
        {
            var value = HttpContext.Session.GetString(key);
            revendas revenda = Newtonsoft.Json.JsonConvert.DeserializeObject<revendas>(key);
            return revenda;
        }
        
        public void SetConfiguracao(configuracoes value)
        {            
            HttpContext.Session.SetString("configuracao", JsonConvert.SerializeObject(value));
        }
        
        public configuracoes GetConfiguracao(string key)
        {
            var value = HttpContext.Session.GetString(key);
            configuracoes configuracao = Newtonsoft.Json.JsonConvert.DeserializeObject<configuracoes>(key);
            return configuracao;
        }

        public void SetStreaming(streamings value)
        {
            HttpContext.Session.SetString("streaming", JsonConvert.SerializeObject(value));
        }

        public streamings GetStreaming(string key)
        {
            var value = HttpContext.Session.GetString(key);
            streamings streaming = Newtonsoft.Json.JsonConvert.DeserializeObject<streamings>(key);
            return streaming;
        }

        public void SetServidor(servidores value)
        {
            HttpContext.Session.SetString("servidor", JsonConvert.SerializeObject(value));
        }

        public servidores GetServidor(string key)
        {
            var value = HttpContext.Session.GetString(key);
            servidores servidor = Newtonsoft.Json.JsonConvert.DeserializeObject<servidores>(key);
            return servidor;
        }
        #endregion

    }
}
