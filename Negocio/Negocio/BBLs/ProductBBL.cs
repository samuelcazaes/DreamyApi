using Comunicacao.ViewModels.Product;
using DreamyApi.Dominio.Models;
using Helpers;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Negocio.BBLs
{
    public class ProductBBL : NegocioBase
    {
        public ProductBBL() : base() { }
        
        public string SaveProduct(ProdutoViewModel produto)
        {
            try
            {                
                Produtos productToSave = new()
                {
                    Nome = produto.Nome,
                    Description = produto.Description,
                    Price = produto.Price,
                };

                db.Produtos.Add(productToSave);
                db.SaveChanges();
                return ProductMessages.SuccessSavingProduct;
            }
            catch (Exception ex)
            {
                LogBBL.Write(ex.ToString(), ex.Message, ProductMessages.ProductSaveException);
                return null;
            }
        }

        public ProdutoViewModel GetProduct(int produtoId)
        {
            try
            {
                if (produtoId == 0)
                {
                    return null;
                }

                Produtos productDB = db.Produtos.Where(x => x.Id == produtoId).FirstOrDefault();

                ProdutoViewModel productView = new()
                {
                    Id = productDB.Id,
                    Nome = productDB.Nome,
                    Description = productDB.Description,
                    Price = productDB.Price,
                };
              
                return productView;
            }
            catch (Exception ex)
            {
                LogBBL.Write(ex.ToString(), ex.Message, ProductMessages.ProductFindException);
                return null;
            }
        }

        public List<ProdutoViewModel> GetAllProduct()
        {
            try
            {
                List<ProdutoViewModel> response = new();
         
                List<Produtos> productList = db.Produtos.ToList();

                foreach(Produtos produto in productList)
                {
                    ProdutoViewModel productView = new()
                    {
                        Id = produto.Id,
                        Nome = produto.Nome,
                        Description = produto.Description,
                        Price = produto.Price,
                    };

                    if (productView != null)
                        response.Add(productView);
                    continue;
                }
                return response;
            }
            catch (Exception ex)
            {
                LogBBL.Write(ex.ToString(), ex.Message, ProductMessages.ProductFindException);
                return null;
            }
        }

        public Produtos GetProductDb(int produtoId)
        {
            try
            {
                if (produtoId == 0)
                {
                    return null;
                }

                Produtos productDB = db.Produtos.Where(x => x.Id == produtoId).FirstOrDefault();
      
                return productDB;
            }
            catch (Exception ex)
            {
                LogBBL.Write(ex.ToString(), ex.Message, ProductMessages.ProductFindException);
                return null;
            }
        }

        public string UpdateProduct(ProdutoViewModel produto)
        {
            try
            {
                if (produto == null)           
                    return ProductMessages.NoContentUpdateProduct;
                
                Produtos productToSave = GetProductDb(produto.Id);

                if (productToSave == null)
                    return ProductMessages.ProductNotFind;

                if (!string.IsNullOrEmpty(produto.Nome))
                    productToSave.Nome = produto.Nome;

                if (produto.Price != 0)
                    productToSave.Price = produto.Price;

                if (!string.IsNullOrEmpty(produto.Description))
                    productToSave.Description = produto.Description;
               
                db.SaveChanges();
                return ProductMessages.SuccessUpdatingProduct;
            }
            catch (Exception ex)
            {
                LogBBL.Write(ex.ToString(), ex.Message, ProductMessages.ProductUpdateException);
                return null;
            }
        }

        public string DeleteProduct(int produtoId)
        {
            try
            {
                if (produtoId == 0)
                {
                    return ProductMessages.GetProductNoId;
                }

                Produtos productToRemove = GetProductDb(produtoId);

                if (productToRemove == null)
                {
                    return ProductMessages.ProductNotFind;
                }

                db.Produtos.Remove(productToRemove);
                db.SaveChanges();

                Produtos productVerify = GetProductDb(produtoId);

                if (productVerify != null)
                {
                    return ProductMessages.ErrorRemovingProduct;
                }
                return ProductMessages.SuccessRemovingProduct;
            }
            catch (Exception ex)
            {
                LogBBL.Write(ex.ToString(), ex.Message, ProductMessages.ProductRemovingException);
                return null;
            }
        }
    }
}
