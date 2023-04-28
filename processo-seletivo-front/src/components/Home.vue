<template>
    <div class="home">

        <h1>Funcionários</h1>

        <div style="display: flex; align-items: center; margin: 10px 0px;">
            Foram carregados {{ funcionarios.length }} itens
            <span class="botaoAcao"><Button label="Novo Funcionário" @click.prevent="mostraDialogNovoFuncionario()" icon="pi pi-plus" class="p-button-rounded p-button-sm" /></span>
            <span class="botaoAcao"><Button label="Atualizar Dados" @click.prevent="carregaFuncionarios()" icon="pi pi-refresh" class="botaoAcao p-button-rounded p-button-sm" /></span>
        </div>

        <DataTable :value="funcionarios" responsiveLayout="scroll" autoLayout="true" class="p-datatable-sm">
            <Column field="id" header="Id"></Column>
            <Column field="nome" header="Nome"></Column>
            <Column field="dataNascimento" header="Data Nascimento"></Column>
            <Column field="cpf" header="CPF"></Column>
            <Column field="email" header="E-Mail"></Column>
            <!-- coluna com o botão de alteração do registro sendo mostrado na linha -->
            <Column field="id" header="Alterar">
                <template #body="slotProps">
                    <Button icon="pi pi-pencil" class="p-button-rounded p-button-sm" @click.prevent="mostraDialogAlterarFuncionario(slotProps.data.id)" />
                </template>
            </Column>
            <!-- coluna com o botão de exclusão do registro sendo mostrado na linha -->
            <Column field="id" header="Excluir" />
        </DataTable>

        <Dialog header="Novo Funcionário" modal="true" :visible.sync="mostraNovoFuncionario" :contentStyle="{overflow: 'visible'}"  :containerStyle="{width: '50vw'}">
            <NovoFuncionario />
        </Dialog>

    </div>
</template>

<script>


    import DataTable from 'primevue/datatable';
    import Column from 'primevue/column';
    import Button from 'primevue/button';
    import Dialog from 'primevue/dialog';
    import NovoFuncionario from './NovoFuncionario.vue';


    export default {

        name: 'Home',

        data() {
            return {

                // Lista de funcionários a mostrar 
                funcionarios: [],

                mostraNovoFuncionario: false
            }
        },

        // ---
        // Evento executado na inicialização deste componente
        // ---
        async mounted() {
            await this.carregaFuncionarios();
        },

        // ---
        // Métodos do componente
        // ---
        methods: {

            // ---
            // Carrega a lista de funcionários
            // ---
            async carregaFuncionarios() {
                try {
                    // Chamada à API de carga dos dados
                    console.log("chamando API: GET ", this.$urlApi + "/Funcionarios");
                    var result = await this.$http.get(this.$urlApi + "/Funcionarios");
                    this.funcionarios = result.data;
                }
                catch (err) {
                    console.log("ERRO:", err);
                    alert("ERRO: " + err.message);
                }
            },

            // ---
            // Faz aparecer a dialog box de inclusão de novo funcionário
            // ---
            mostraDialogNovoFuncionario() {
                this.mostraNovoFuncionario = true;
            },

            // ---
            // Faz aparecer a dialog box de edição de funcionário
            // ---
            mostraDialogAlterarFuncionario(idFuncionario) {
                alert('Editando funcionario id: ' + idFuncionario);
            }

        },

        components: { DataTable, Column, Button, Dialog, NovoFuncionario }
    };
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style>
    body {
        font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
        padding: 0px 50px;
    }

    h1 {
        font-size: 70px;
        font-weight: 600;
    }

    .botaoAcao {
        margin-left: 10px;
    }
</style>

