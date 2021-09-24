﻿using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace serverside_aspnet.Models
{
    [Serializable]
    public class ComponenteModel
    {
        private string _identificadorDaPropriedade;

        public string Propriedade { get; set; }

        public bool Obrigatorio { get; set; }

        public int QtdDeItensRetornados { get; set; }

        public IDictionary<string, object> HtmlAttributes { get; set; }

        public string Controller { get; set; }

        public string Action { get; set; }

        public string Colunas { get; set; }

        public string CampoChave { get; set; }

        public string[] CamposTemplate { get; set; }

        public string ItemSelecionado { get; set; }

        public object Objeto { get; set; }

        public virtual string IdentificadorDaPropriedade
        {
            get
            {
                return !string.IsNullOrEmpty(_identificadorDaPropriedade)
                               ? Regex.Replace(_identificadorDaPropriedade, "[\\[|\\]|\\.]", "_")
                               : Regex.Replace(Propriedade, "[\\[|\\]|\\.]", "_");
            }
            set
            {
                _identificadorDaPropriedade = value;
            }
        }
    }
}
