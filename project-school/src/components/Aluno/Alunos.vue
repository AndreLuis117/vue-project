<template>
  <div class="hello">
    <titulo texto="Aluno"/>
    <div>
          <input type="text" placeholder="Nome do Aluno" v-model="nome" v-on:keyup.enter="addAluno()">
          <button class="btn btn_input" @click="addAluno()">Adicionar</button>
    </div>

    <table>
      <thead>
      <th>Mat.</th>
      <th>Nome</th>
      <th>Opções</th>
    </thead>
    <tbody v-if="alunos.length">
      <tr v-for="(aluno, index) in alunos" :key="index">
        <td>{{aluno.id}}</td>
        <td>{{aluno.nome}} {{aluno.sobrenome}}</td>
        <td><button class="btn btn_danger" @click="remover(aluno)">Remover</button></td>
      </tr>
    </tbody>
    <tfoot v-else>
      Nenhum aluno encontrado!
    </tfoot>
    </table>
  </div>
</template>

<script>
import Titulo from '../_shared/Titulo.vue'
export default {
  components: {
    Titulo
  },
  data(){
    return{
      titulo: 'Aluno',
      nome: '',
      alunos: []
    }
  },
  created() {
    this.$http.get('http://localhost:3000/alunos')
    .then(res => res.json())
    .then(alunos => this.alunos = alunos)
  },
  props: {
  },
  methods: {
    addAluno() {
      let _aluno = {
        nome: this.nome,
        sobrenome: ""
      }

      this.$http.post('http://localhost:3000/alunos', _aluno)
      .then(res => res.json())
      .then(aluno => {
        this.alunos.push(aluno)
        this.nome = '';
      })

    },
    remover(aluno){

      this.$http.delete(`http://localhost:3000/alunos/${aluno.id}`)
      .then(() =>{
        let indice = this.alunos.indexOf(aluno);
        this.alunos.splice(indice, 1);
      })

    }
  },
}
</script>

<style scoped>
  input{
    border: 0;
    padding: 20px;
    font-size: 1.3em;
    color: #697f7f;
    display: inline;
  }

  .btn_input{
    width: 150px;
    border: 0px;
    padding: 20px;
    font-size: 1.3em;
    display: inline;
    background-color: rgb(116, 115, 115);
  }

    .btn_input{
      padding: 20;
      margin: 0;
      border: 0;
    }
</style>
