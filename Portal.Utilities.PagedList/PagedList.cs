﻿using Portal.Utilities.PagedList.Helpers;
using Portal.Utilities.PagedList.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Utilities.PagedList
{
    /// <summary>
    /// Classe de paginação
    /// </summary>
    public class PagedList
    {

        /// <summary>
        /// Construtor da lista paginada, responsável por montar toda lista e entregar objeto pronto para o uso.
        /// </summary>
        /// <param name="OriginUrl">URL completa de Origem</param>
        /// <param name="ItemCount">Total de Itens em todas as Páginas</param>
        /// <param name="PageNumber">Página Corrente</param>
        /// <param name="PageSize">Tamanho máximo de itens por página</param>
        /// <param name="NavigatorSize">Tamanho máximo para exibição da navegação numérica, se não informado, não gera essa navegação</param>
        public PagedList(
            string OriginUrl, 
            long ItemCount, 
            int PageNumber = PageOptions.PAGE_NUMBER_DEFAULT,
            int PageSize = PageOptions.PAGE_SIZE_DEFAULT,
            int? NavigatorSize = null
        ) {
            // Inicializa opções de página
            pageOptions = new PageOptions(ItemCount, PageNumber, PageSize);

            // Remove pageNumber da URL
            string[] parameters = {"pageNumber"};
            OriginUrl = UrlHelper.RemoveParameterFromQueryString(OriginUrl, parameters);

            // Inicializa Navegador de URL
            urlNavigator = new UrlNavigator(OriginUrl, pageOptions.pageNumber, pageOptions.pageCount, NavigatorSize);
        }

        /// <summary>
        /// Opções da página
        /// </summary>
        public PageOptions pageOptions { get; private set; }

        /// <summary>
        /// Navegador de URLs Básicas 
        /// </summary>
        public UrlNavigator urlNavigator { get; private set; }
    }
}
