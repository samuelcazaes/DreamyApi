using System;

namespace Helpers
{
    public static class ProductMessages
    {
        //|---------------------------------|
        //|Error                            |
        //|_________________________________|

        public static string NoContentSaveProduct = "Não foi encontrado nenhum dado de produto para salvar, por favor insira os dados e tente novamente.";
        public static string NoContentUpdateProduct = "Não foi encontrado nenhum dado de produto para editar, por favor insira os dados e tente novamente.";
        public static string ProductNotFind = "Erro, produto não encontrado.";
        public static string ProductSaveException = "Ocorreu uma exceção ao tentar salvar produto, por favor averiguar a tabela de log.";
        public static string ProductFindException = "Ocorreu uma exceção ao tentar achar produto, por favor averiguar a tabela de log.";
        public static string ProductFindAllException = "Ocorreu uma exceção ao tentar achar os produtos, por favor averiguar a tabela de log.";
        public static string ErrorProductFindAll = "Ocorreu um erro ao tentar buscar pelos produtos, lamentamos pelo transtorno";
        public static string ProductUpdateException = "Ocorreu uma exceção ao tentar atualizar produto, por favor averiguar a tabela de log.";
        public static string ProductRemovingException = "Ocorreu uma exceção ao tentar remover o produto, por favor averiguar a tabela de log.";
        public static string GetProductNoId = "Produto não encontrado, por favor insíra um Id acima de 0.";
        public static string ErrorSavingProduct = "Erro, não foi possivel salvar o produto";
        public static string ErrorUpdatingProduct = "Ocorreu um erro ao tentar atualizar o produto";
        public static string ErrorRemovingProduct = "Erro, o produto não foi removido";

        //|---------------------------------|
        //|Success                          |
        //|_________________________________|

        public static string SuccessSavingProduct = "Sucesso ao salvar produto.";
        public static string SuccessRemovingProduct = "Sucesso ao remover produto.";
        public static string SuccessFindingProduct = "Sucesso ao buscar pelo produto.";
        public static string SuccessFindAllProduct = "Sucesso ao buscar pelos produtos.";
        public static string SuccessUpdatingProduct = "Sucesso ao editar produto.";

    }
}
