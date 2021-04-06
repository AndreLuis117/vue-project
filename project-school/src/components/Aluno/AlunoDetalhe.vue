<template>
  <div v-if="!loading">
    <titulo :texto="`Aluno ${aluno.nome}`" :btnVoltar="!visualizando">
      <button v-show="visualizando" class="btn btnEditar" @click="editar()">
        Editar
      </button>
    </titulo>
    <table>
      <tbody>
        <tr>
          <td class="colPequeno">Matrícula:</td>
          <td>
            <label for="">{{ aluno.id }}</label>
          </td>
        </tr>
        <tr>
          <td class="colPequeno">Nome:</td>
          <td>
            <label v-if="visualizando" for="">{{ aluno.nome }}</label>
            <input v-else v-model="aluno.nome" type="text" />
          </td>
        </tr>
        <tr>
          <td class="colPequeno">Sobrenome:</td>
          <td>
            <label v-if="visualizando" for="">{{ aluno.sobrenome }}</label>
            <input v-else v-model="aluno.sobrenome" type="text" />
          </td>
        </tr>
        <tr>
          <td class="colPequeno">Data Nascimento:</td>
          <td>
            <label v-if="visualizando" for="">{{ aluno.dataNasc }}</label>
            <input v-else v-model="aluno.dataNasc" type="text" />
          </td>
        </tr>
        <tr>
          <td class="colPequeno">Professor:</td>
          <td>
            <label v-if="visualizando" for="">{{ aluno.professor.nome }}</label>
            <select v-else v-model="aluno.professor.id">
              <option
                v-for="(professor, index) in professores"
                :key="index"
                v-bind:value="professor.id"
              >
                {{ professor.nome }}
              </option>
            </select>
          </td>
        </tr>
      </tbody>
    </table>

    <div style="margin-top: 10px">
      <div v-if="!visualizando">
        <button class="btn btnSalvar" @click="salvar(aluno)">Salvar</button>
        <button class="btn btnCancelar" @click="cancelar()">Cancelar</button>
      </div>
    </div>
  </div>
</template>

<script>
import Titulo from "../_shared/Titulo";
export default {
  components: {
    Titulo,
  },
  data() {
    return {
      professores: [],
      aluno: {},
      id: this.$route.params.id,
      visualizando: true,
      loading: true,
    };
  },
  created() {
    this.carregarProfessor();
  },
  methods: {
    carregarProfessor() {
      this.$http
        .get("https://localhost:44315/api/professor")
        .then((res) => res.json())
        .then((professor) => {
          this.professores = professor;
          this.carregarAluno();
          });
    },
    carregarAluno() {
      this.$http
        .get("https://localhost:44315/api/aluno/" + this.id)
        .then((res) => res.json())
        .then((aluno) => {
          this.aluno = aluno;
          this.loading = false;
          });
    },
    editar() {
      this.visualizando = !this.visualizando;
    },
    salvar(_aluno) {
      let _alunoEditar = {
        id: _aluno.id,
        nome: _aluno.nome,
        sobrenome: _aluno.sobrenome,
        dataNasc: _aluno.dataNasc,
        professorId: _aluno.professor.id,
      };

      this.$http
        .put(
          `https://localhost:44315/api/aluno/${_alunoEditar.id}`,
          _alunoEditar
        )
        .then((res) => res.json())
        .then((aluno) => (this.aluno = aluno))
        .then(() => this.visualizando = true);

      this.visualizando = !this.visualizando;
    },
    cancelar() {
      this.visualizando = !this.visualizando;
    },
  },
};
</script>

<style scoped>
.btnEditar {
  float: right;
  background-color: rgb(76, 186, 249);
}
.btnSalvar {
  float: right;
  background-color: rgb(79, 196, 68);
}
.btnCancelar {
  float: left;
  background-color: rgb(249, 186, 92);
}

.colPequeno {
  width: 20%;
}

input,
select {
  margin: 0px;
  padding: 5px 10px;
  font-size: 0.9em;
  border: 1px solid silver;
  border-radius: 5px;
  font-family: Montserrat;
  width: 95%;
  background-color: rgb(245, 245, 245);
}
select {
  height: 38px;
  width: 30%;
}
</style>