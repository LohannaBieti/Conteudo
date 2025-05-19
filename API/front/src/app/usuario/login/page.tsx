"use client";

import React, {useState} from "react";

function Login() {
    const [email, setEmail] = useState("");
    const [senha, setSenha] = useState("");

    function efetuarLogin(e : React.FormEvent){
        e.preventDefault();

        const resposta = await fetch("http://localhost:5125/api/usuario"

            {
                method: "POST",
                headers :{
                    "Content-Type": "aplication/json",
                },
                body: JSON.stringify({ email, senha }),
            }
        );
    }
    return (
        <div>
            <h1>Login</h1>
            <form onSubmit={efetuarLogin}>
                <div id="email">
                    <label htmlFor="email">E-mail:</label>
                </div>
            </form>
        </div>
    )
}
