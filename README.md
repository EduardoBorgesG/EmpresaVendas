SCRIPTS PARA CRIAÇÃO DO BANCO DE DADOS

Criação da DataBase:

-- Database: empresa_venda

-- DROP DATABASE IF EXISTS empresa_venda;

CREATE DATABASE empresa_venda
    WITH
    OWNER = postgres
    ENCODING = 'UTF8'
    LC_COLLATE = 'Portuguese_Brazil.1252'
    LC_CTYPE = 'Portuguese_Brazil.1252'
    LOCALE_PROVIDER = 'libc'
    TABLESPACE = pg_default
    CONNECTION LIMIT = -1
    IS_TEMPLATE = False;
----------------------------------------------------------------------------------
Criação da tabela cliente :

-- Table: public.c_clientes_tb
-- DROP TABLE IF EXISTS public.c_clientes_tb;
-- O id usa IDENTITY: o PostgreSQL cria e gerencia a sequence automaticamente
-- O telefone é único porque é o campo que o sistema usa para identificar cliente duplicado
CREATE TABLE IF NOT EXISTS public.c_clientes_tb
(
    id integer GENERATED ALWAYS AS IDENTITY,
    nome character varying(250),
    email character varying(250),
    telefone character varying(15),
    cep character varying(10),
    endereco character varying(250),
    ativo boolean,
    CONSTRAINT c_clientes_tb_pkey PRIMARY KEY (id),
    CONSTRAINT cliente_telefone UNIQUE (telefone)
)
TABLESPACE pg_default;
ALTER TABLE IF EXISTS public.c_clientes_tb
    OWNER to postgres;
---------------------------------------------------------------------------------------
Criação da tabela produto

-- Table: public.p_produtos_tb
-- DROP TABLE IF EXISTS public.p_produtos_tb;
CREATE TABLE IF NOT EXISTS public.p_produtos_tb
(
    id integer GENERATED ALWAYS AS IDENTITY,
    nome character varying(250),
    descricao character varying(350),
    estoque integer,
    preco_produto numeric(10,2),
    ativo boolean,
    CONSTRAINT p_produto_tb_pkey PRIMARY KEY (id),
    CONSTRAINT nome UNIQUE (nome)
)
TABLESPACE pg_default;
ALTER TABLE IF EXISTS public.p_produtos_tb
    OWNER to postgres;
-- Index: idx_id_nome
-- DROP INDEX IF EXISTS public.idx_id_nome;
CREATE INDEX IF NOT EXISTS idx_id_nome
    ON public.p_produtos_tb USING btree
    (id ASC NULLS LAST, nome ASC NULLS LAST)
    TABLESPACE pg_default;
-------------------------------------------------------------------------------------------------

Criação da tabela v_vendas_tb:

-- Table: public.v_vendas_tb
-- DROP TABLE IF EXISTS public.v_vendas_tb;
CREATE TABLE IF NOT EXISTS public.v_vendas_tb
(
    id integer GENERATED ALWAYS AS IDENTITY,
    valor_pago numeric(10,2),
    nome_cliente_id integer,
    CONSTRAINT "v_vendas.tb_pkey" PRIMARY KEY (id),
    CONSTRAINT cliente_id FOREIGN KEY (nome_cliente_id)
        REFERENCES public.c_clientes_tb (id) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
)
TABLESPACE pg_default;
ALTER TABLE IF EXISTS public.v_vendas_tb
    OWNER to postgres;

-----------------------------------------------------------------------------------------------

Criação da tabela v_vendas_itens_tb


-- Table: public.v_vendas_item_tb
-- DROP TABLE IF EXISTS public.v_vendas_item_tb;
CREATE TABLE IF NOT EXISTS public.v_vendas_item_tb
(
    id integer GENERATED ALWAYS AS IDENTITY,
    venda_id integer,
    produto_id integer,
    quantidade integer,
    CONSTRAINT v_detalhes_vendas_tb_pkey PRIMARY KEY (id),
    CONSTRAINT produto_id FOREIGN KEY (produto_id)
        REFERENCES public.p_produtos_tb (id) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION,
    CONSTRAINT venda_id FOREIGN KEY (venda_id)
        REFERENCES public.v_vendas_tb (id) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
)
TABLESPACE pg_default;
ALTER TABLE IF EXISTS public.v_vendas_item_tb
    OWNER to postgres;


---------------------------------------------------------------------------------------------------

Criação da view do relatório

-- View: public.v_relatorio_vendas
-- DROP VIEW public.v_relatorio_vendas;
CREATE OR REPLACE VIEW public.v_relatorio_vendas
 AS
 SELECT c.nome AS nomecliente,
    string_agg(((p.nome::text || ' (Qtd: '::text) || vi.quantidade) || ')'::text, ', '::text) AS produtos,
    -- Soma o valor de cada venda uma única vez (somar após o JOIN com os itens multiplicava o valor pela quantidade de itens)
    ( SELECT sum(v2.valor_pago)
        FROM v_vendas_tb v2
       WHERE v2.nome_cliente_id = c.id) AS valortotal
   FROM v_vendas_tb v
     JOIN v_vendas_item_tb vi ON v.id = vi.venda_id
     JOIN p_produtos_tb p ON vi.produto_id = p.id
     JOIN c_clientes_tb c ON v.nome_cliente_id = c.id
  GROUP BY c.id, c.nome;
ALTER TABLE public.v_relatorio_vendas
    OWNER TO postgres;

---------------------------------------------------------------------------------------------------

Banco já existente (criado com o script antigo)

-- Os CREATE TABLE IF NOT EXISTS acima não alteram tabelas que já existem.
-- Para trocar a restrição de nome único por telefone único em clientes, execute:
ALTER TABLE public.c_clientes_tb DROP CONSTRAINT IF EXISTS cliente;
ALTER TABLE public.c_clientes_tb ADD CONSTRAINT cliente_telefone UNIQUE (telefone);
