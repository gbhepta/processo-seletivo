<template>
    <div style="width: 100%">
        <div class="campoForm">
            <span class="p-float-label">
                <InputText id="nome" type="text" v-model="funcionario.nome"  style="width:70%"  />
                <label for="nome">Nome</label>
            </span>
        </div>
        <div class="campoForm">
            <span class="p-float-label">
                <Calendar id="dataNascimento" v-model="funcionario.dataNascimento" dateFormat="dd/mm/yy" style="width:70%" />
                <label for="dataNascimento">Data de Nascimento</label>
            </span>
        </div>
        <div class="campoForm">
            <span class="p-float-label">
                <InputText id="cpf" type="text" v-model="funcionario.cpf" style="width:70%" />
                <label for="nome">CPF</label>
            </span>
        </div>
        <div class="campoForm">
            <span class="p-float-label">
                <InputText id="email" type="text" v-model="funcionario.email"  style="width:70%"  />
                <label for="nome">E-Mail</label>
            </span>
        </div>
        <div class="campoForm">
            <span class="botaoAcao"><Button icon="pi pi-check" class="p-button-raised p-button-rounded p-button-sm da-ed" label="Salvar" @click="salvarFuncionario()" /></span>
        </div>
    </div>
</template>

<script>


    import InputText from 'primevue/inputtext';
    import Calendar from 'primevue/calendar';
    import Button from 'primevue/button';
    //import Dropdown from 'primevue/dropdown';


    export default {

        data() {
            return {

                funcionario: {
                    nome: '',
                    dataNascimento: null,
                    cpf: '',
                    email: '',
                    idLotacao: 1    // Lotação fixa - deveria ser obtida de um campo do formulário
                }

            }
        },

        methods: {

            // ---
            // Cria um novo funcionário no BD com os valores especificados no objeto this.funcionario
            // ---
            async salvarFuncionario() {
                try {
                    // Chamada à API de gravação dos dados

                }
                catch (err) {
                    console.log("ERRO:", err);
                    alert("ERRO: " + err.message);
                }
            }

        },

        components: { InputText, Calendar, Button /*, Dropdown*/}

    }

</script>

<style scoped>

    .campoForm {
        margin-top: 30px;
        width: 100%; /* min(calc(100% - 4rem), 600px); */
    }

</style>