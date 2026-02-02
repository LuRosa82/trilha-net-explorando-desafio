
# Desafio – Projeto de Hospedagem (Console/.NET 8)

Mini‑sistema de **reservas de hospedagem** em modo console, desenvolvido em **.NET 8**.  
O usuário pode cadastrar **suítes**, **hóspedes**, criar/atualizar **reservas**, e calcular o **valor total** com **desconto** automático para longas estadias.

> Regra de desconto: para **10 dias ou mais**, aplicar **10%** sobre o total.

---

## 🧭 Índice
- Funções do sistema
- Tecnologias
- Requisitos
- Como executar
- Menu do sistema
- Estrutura do projeto
- Regras de negócio
- Exemplos de uso
- Como contribuir
- Licença

---

## ✨ Funcionalidades
- Cadastro de **suíte** com tipo, capacidade e valor da diária.
- Cadastro de **hóspedes** (nome e sobrenome).
- Criação/atualização de **reserva** informando os dias.
- **Validação de capacidade**: a quantidade de hóspedes deve caber na suíte.
- **Cálculo do valor** total da reserva (com desconto para ≥ 10 dias).
- Exibição de **resumo** (suíte, hóspedes, valor).
- Interface **interativa** por **menu no console**.

---

## 🛠 Tecnologias
- **.NET 8 (SDK)**
- **C#**
- Console App (Top‑Level Statements)

---

## 💻 Requisitos
- **.NET SDK 8.0**

---

## ▶️ Como executar
Clone o repositório e rode:

```bash
dotnet restore
dotnet run

Menu do sistema
=======================================
      Sistema de Reservas (Console)
=======================================

[1] Cadastrar suíte
[2] Cadastrar hóspedes
[3] Criar/atualizar reserva
[4] Mostrar resumo
[5] Mostrar quantidade de hóspedes
[6] Calcular valor da diária
[0] Sair


Estrutura do projeto
.
├─ Program.cs                 # Menu interativo (console)
├─ ConsoleUtils.cs            # Utilitários de entrada/validação
├─ Models/
│  ├─ Pessoa.cs               # Nome/Sobrenome
│  ├─ Suite.cs                # Tipo, Capacidade, ValorDiaria
│  └─ Reserva.cs              # Regras de reserva e cálculo
└─ DesafioProjetoHospedagem.csproj

📐 Regras de negócio
Cadastro de hóspedes

Não permite cadastrar sem antes definir a suíte
Não permite cadastrar lista vazia
Não permite ultrapassar capacidade da suíte

Cálculo de diária

Total = Dias × Valor da diária
Se dias ≥ 10 → 10% de desconto

🧪 Exemplos de uso
Sem desconto

Suíte: diária 30,00
Dias: 5
Total: 150,00

Com desconto

Suíte: diária 30,00
Dias: 12
Total: 324,00


🤝 Como contribuir

Faça um fork
Crie uma branch
Commit
Push
Abra um Pull Request


📜 Licença
Projeto criado para fins de estudo em C# e .NET.
EOF

Isso vai criar automaticamente o arquivo pronto! ✔️

---

# ✅ **2. Adicionar ao Git**
```bash
git add README.md

✅ 3. Fazer o commit
git commit -m "docs: adiciona README.md ao projeto"Mostrar mais linhas

✅ 4. Enviar para o GitHub
git push origin main
