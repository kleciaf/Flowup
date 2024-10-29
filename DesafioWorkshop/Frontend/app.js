const apiUrl = 'http://localhost:5069/api/colaborador';
const colaboradorList = document.getElementById('colaboradorList');
const addColaboradorBtn = document.getElementById('addColaboradorBtn');
const colaboradorNomeInput = document.getElementById('colaboradorNome');

function fetchColaboradores() {
    fetch(apiUrl)
        .then(response => response.json())
        .then(data => {
            colaboradorList.innerHTML = '';
            data.forEach(colaborador => {
                const li = document.createElement('li');
                li.textContent = colaborador.nome;
                colaboradorList.appendChild(li);
            });
        })
        .catch(error => console.error('Erro ao buscar colaboradores:', error));
}

addColaboradorBtn.addEventListener('click', () => {
    const nome = colaboradorNomeInput.value;
    if (nome) {
        fetch(apiUrl, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({ nome }),
        })
        .then(response => {
            if (response.ok) {
                fetchColaboradores();
                colaboradorNomeInput.value = '';
            }
        })
        .catch(error => console.error('Erro ao adicionar colaborador:', error));
    }
});

// Carregar colaboradores ao iniciar
fetchColaboradores();
