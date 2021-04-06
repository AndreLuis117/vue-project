<template>
  <div class="hello">
    <titulo :texto="professorId != undefined ? 'Professor: ' + professor.nome : 'Todos os alunos'" btnVoltar="true"/>
    <div v-if="professorId != undefined">
      <input
        type="text"
        placeholder="Nome do Aluno"
        v-model="nome"
        v-on:keyup.enter="addAluno()"
      />
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
          <td class="colPequeno" >{{ aluno.id }}</td>
          <router-link :to="`/alunoDetalhe/${aluno.id}`" tag="td" style="cursor: pointer">
            {{ aluno.nome }} {{ aluno.sobrenome }}
          </router-link>
          <td class="colPequeno">
            <button class="btn btn_danger" @click="remover(aluno)">
              Remover
            </button>
          </td>
        </tr>
      </tbody>
      <tfoot v-else>
        <tr>
          <td colspan="3" style="text-align: center">
              <h5>Nenhum aluno encontrado!</h5>
          </td>
        </tr>
        
      </tfoot>
    </table>
  </div>
</template>

<script>
import Titulo from "../_shared/Titulo.vue";
export default {
  components: {
    Titulo,
  },
  data() {
    return {
      titulo: "Aluno",
      professorId: this.$route.params.prof_id,
      professor: {},
      nome: "",
      alunos: [],
    };
  },
  created() {
    if (this.professorId) {
      this.carregaProfessores();
      this.$http
        .get(`https://localhost:44315/api/aluno/ByProfessor/${this.professorId}`)
        .then((res) => res.json())
        .then((alunos) => (this.alunos = alunos));
    } else {
      this.$http
        .get("https://localhost:44315/api/aluno")
        .then((res) => res.json())
        .then((alunos) => (this.alunos = alunos));
    }
  },
  props: {},
  methods: {
    addAluno() {
      let _aluno = {
        nome: this.nome,
        sobrenome: "",
        dataNasc: "",
        professorId: this.professor.id
      };

      this.$http
        .post("https://localhost:44315/api/aluno", _aluno)
        .then((res) => res.json())
        .then((aluno) => {
          this.alunos.push(aluno);
          this.nome = "";
        });
    },
    remover(aluno) {
      this.$http.delete(`https://localhost:44315/api/aluno/${aluno.id}`).then(() => {
        let indice = this.alunos.indexOf(aluno);
        this.alunos.splice(indice, 1);
      });
    },

    carregaProfessores(){
      this.$http
      .get("https://localhost:44315/api/professor/" +  this.professorId)
      .then((res) => res.json())
      .then(professor => {
        this.professor = professor
      });
    }
  },
};
</script>

<style scoped>
input {
  width: calc(100% - 195px);
  border: 0;
  padding: 20px;
  font-size: 1.3em;
  color: #697f7f;
  display: inline;
}

.btn_input {
  width: 150px;
  width: 150px;
  border: 0px;
  padding: 20px;
  font-size: 1.3em;
  display: inline;
  background-color: rgb(116, 115, 115);
}

.btn_input {
  padding: 20;
  margin: 0;
  border: 0;
}
</style>
