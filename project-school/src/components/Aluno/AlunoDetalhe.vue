<template>
    <div>
        <titulo :texto="`Aluno ${aluno.nome}`"></titulo>
        <table>
        <tbody>
            <tr>
                <td class="colPequeno">Matrícula:</td>
                <td>
                    <label for="">{{aluno.id}}</label> 
                    <input v-model="aluno.id" type="text">

                    </td>
            </tr>
            <tr>
                <td>Nome: </td>
                <td>
                    <label for="">{{aluno.nome}}</label>
                    <input v-model="aluno.nome" type="text">
                    </td>
            </tr>
            <tr>
                <td>Sobrenome: </td>
                <td>
                    <label for="">{{aluno.sobrenome}}</label> 
                    <input v-model="aluno.sobrenome" type="text">
                    </td>
            </tr>
            <tr>
                <td>Data Nascimento: </td>
                <td>
                    <label for="">{{aluno.dataNasc}}</label> 
                    <input v-model="aluno.dataNasc" type="text">
                    </td>
            </tr>
            <tr>
                <td>Professor: </td>
                <td>
                    <label for="">{{aluno.professor.nome}}</label> 
                    </td>
            </tr>
        </tbody>
    </table>
    </div>
    
</template>

<script>
import Titulo from '../_shared/Titulo'
    export default  { 
        components:{
            Titulo
        },
        data(){
            return{
                aluno:{},
                id: this.$route.params.id
            }
        },
        created() {
            this.$http
        .get("http://localhost:3000/alunos/"+ this.id)
        .then((res) => res.json())
        .then((aluno) => (this.aluno = aluno));
        },
        methods: {
            
        },
       
      }
</script>

<style>

</style>