"use client";
import api from "@/app/services/api";
import Produto from "@/app/types/produto";
//import axios from "axios";
import { useEffect, useState } from "react";

function ProdutoListar(){
  const [produtos, setProdutos] = useState<Produto[]>([]);

  useEffect(() => {
    api.get<Produto[]>("/produto/listar")
    .then((resposta) => {
      setProdutos(resposta.data);
      console.table(resposta.data)
    })
    .catch((erro) => {
      console.log(erro);
    });
  },[]);
  return(
    <div>
      <h1>Listar Produtos</h1>
      <ul>
        {produtos.map((produto) =>(<li key={produto.id}>{produto.nome}</li>))}
      </ul>
    </div>
  );
}

export default ProdutoListar;