CREATE TABLE Categoria (
    Id INT NOT NULL IDENTITY(1,1),
    Nome NVARCHAR(100) NOT NULL,

    CONSTRAINT PK_Categoria
        PRIMARY KEY (Id),

    CONSTRAINT UQ_Categoria_Nome
        UNIQUE (Nome)
);

CREATE TABLE Chamado (
    Id INT NOT NULL IDENTITY(1,1),

    Titulo NVARCHAR(200) NOT NULL,

    Descricao NVARCHAR(MAX) NOT NULL,

    Prioridade VARCHAR(20) NOT NULL
    CHECK (Prioridade IN ('Baixa', 'Media', 'Alta')),

    Status VARCHAR(20) NOT NULL
    CHECK (Status IN ('Aberto', 'EmAndamento', 'Fechado')),

    SolicitanteNome NVARCHAR(150) NOT NULL,

    DataAbertura DATETIME NOT NULL,

    DataFechamento DATETIME NULL,

    Solucao VARCHAR(MAX) NULL,

    CategoriaId INT NOT NULL,

    CONSTRAINT PK_Chamado
        PRIMARY KEY (Id),

    CONSTRAINT FK_Chamado_Categoria
        FOREIGN KEY (CategoriaId)
        REFERENCES Categoria(Id)
        ON DELETE NO ACTION
        ON UPDATE CASCADE
);

CREATE TABLE Interacao (
    Id INT NOT NULL IDENTITY(1,1),

    ChamadoId INT NOT NULL,

    Autor NVARCHAR(150) NOT NULL,

    Mensagem NVARCHAR(MAX) NOT NULL,

    DataRegistro DATETIME NOT NULL,

    CONSTRAINT PK_Interacao
        PRIMARY KEY (Id),

    CONSTRAINT FK_Interacao_Chamado
        FOREIGN KEY (ChamadoId)
        REFERENCES Chamado(Id)
        ON DELETE NO ACTION
        ON UPDATE CASCADE
);