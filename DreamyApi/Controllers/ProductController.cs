using Comunicacao.APIObjects;
using Comunicacao.ViewModels.Product;
using Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Negocio.BBLs;
using System;

namespace DreamyApi.Controllers
{
    /// <summary>
    /// Controller Responsável por gerenciar a parte de produtos do sistema.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        /// <summary>
        /// Save - Responsavel por salvar um produto no banco de dados, enviar dados pelo body.
        /// </summary>  
        [HttpPost]   
        public IActionResult SaveProduct(ProdutoViewModel produto)
        {
            try
            {
                APIResponse response = new();

                if (produto == null)
                {
                    response.Success = false;
                    response.Message = ProductMessages.NoContentSaveProduct;
                    return StatusCode(StatusCodes.Status200OK, response);
                }

                ProductBBL pBBL = new();

                response.Message = pBBL.SaveProduct(produto);

                if (response.Message == null)
                {
                    response.Success = false;
                    response.Message = ProductMessages.ErrorSavingProduct;
                    return StatusCode(StatusCodes.Status200OK, response);
                }

                response.Success = true;
                return StatusCode(StatusCodes.Status200OK, response);

            }
            catch (Exception ex)
            {
                LogBBL.Write(ex.ToString(), ex.Message, ProductMessages.ProductSaveException);
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        /// <summary>
        /// Find - Responsável por buscar produto no banco de dados, passar como parâmetro o productId.
        /// </summary>
        [HttpGet]
        [Route("{productId}")]
        public IActionResult GetProduct(int productId)
        {
            try
            {
                APIResponse response = new();

                if (productId == 0)
                {
                    response.Success = false;
                    response.Message = ProductMessages.GetProductNoId;
                    return StatusCode(StatusCodes.Status200OK, response);
                }

                ProductBBL pBBL = new();

                response.Object = pBBL.GetProduct(productId);

                if (response.Object == null)
                {
                    response.Success = false;
                    response.Message = ProductMessages.ProductNotFind;
                    return StatusCode(StatusCodes.Status200OK, response);
                }

                response.Success = true;
                response.Message = ProductMessages.SuccessFindingProduct;
                return StatusCode(StatusCodes.Status200OK, response);

            }
            catch (Exception ex)
            {
                LogBBL.Write(ex.ToString(), ex.Message, ProductMessages.ProductFindException);
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }


        /// <summary>
        /// Find - Responsável por buscar todos os produtos registrados no banco de dados, sem parâmetros.
        /// </summary>
        [HttpGet]
        public IActionResult GetAllProducts()
        {
            try
            {
                APIResponse response = new();          
                ProductBBL pBBL = new();

                response.Object = pBBL.GetAllProduct();

                if (response.Object == null)
                {
                    response.Success = false;
                    response.Message = ProductMessages.ErrorProductFindAll;
                    return StatusCode(StatusCodes.Status200OK, response);
                }

                response.Success = true;
                response.Message = ProductMessages.SuccessFindAllProduct;
                return StatusCode(StatusCodes.Status200OK, response);

            }
            catch (Exception ex)
            {
                LogBBL.Write(ex.ToString(), ex.Message, ProductMessages.ProductFindException);
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        /// <summary>
        /// Find - Responsável por editar um produto já existente, enviar dados no body.
        /// </summary>
        [HttpPut]
        public IActionResult UpdateProduct(ProdutoViewModel produto)
        {
            try
            {
                APIResponse response = new();

                if (produto == null)
                {
                    response.Success = false;
                    response.Message = ProductMessages.NoContentUpdateProduct;
                    return StatusCode(StatusCodes.Status200OK, response);
                }

                ProductBBL pBBL = new();

                response.Message = pBBL.UpdateProduct(produto);

                if (response.Message == null)
                {
                    response.Success = false;
                    response.Message = ProductMessages.ErrorUpdatingProduct;
                    return StatusCode(StatusCodes.Status200OK, response);
                }

                response.Success = true;
                response.Message = ProductMessages.SuccessUpdatingProduct;
                return StatusCode(StatusCodes.Status200OK, response);

            }
            catch (Exception ex)
            {
                LogBBL.Write(ex.ToString(), ex.Message, ProductMessages.ProductUpdateException);
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        /// <summary>
        /// Find - Responsável por deletar um produto do banco de dados, enviar como parâmetro productId.
        /// </summary>
        [HttpDelete]
        [Route("{produtoId}")]
        public IActionResult DeleteProduct(int produtoId)
        {
            try
            {
                APIResponse response = new();


                if (produtoId == 0)
                {
                    response.Success = false;
                    response.Message = ProductMessages.GetProductNoId;
                    return StatusCode(StatusCodes.Status200OK, response);
                }

                ProductBBL pBBL = new();

                response.Message = pBBL.DeleteProduct(produtoId);
                response.Object = pBBL.GetProductDb(produtoId);

                if (response.Object != null)
                {
                    response.Success = false;
                    response.Message = ProductMessages.ErrorRemovingProduct;
                    return StatusCode(StatusCodes.Status200OK, response);
                }

                response.Success = true;
                response.Message = ProductMessages.SuccessRemovingProduct;
                return StatusCode(StatusCodes.Status200OK, response);

            }
            catch (Exception ex)
            {
                LogBBL.Write(ex.ToString(), ex.Message, ProductMessages.ProductRemovingException);
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
    }
}
