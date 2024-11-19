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
CREATE TABLE IF NOT EXISTS public.c_clientes_tb
(
    id integer NOT NULL DEFAULT nextval('c_clientes_tb_id_seq'::regclass),
    nome character varying(250) COLLATE pg_catalog."default",
    email character varying(250) COLLATE pg_catalog."default",
    telefone character varying(15) COLLATE pg_catalog."default",
    cep character varying(10) COLLATE pg_catalog."default",
    endereco character varying(250) COLLATE pg_catalog."default",
    ativo boolean,
    CONSTRAINT c_clientes_tb_pkey PRIMARY KEY (id),
    CONSTRAINT cliente UNIQUE (nome)
)
TABLESPACE pg_default;=
ALTER TABLE IF EXISTS public.c_clientes_tb
    OWNER to postgres;
---------------------------------------------------------------------------------------
Criação da tabela produto

-- Table: public.p_produtos_tb
-- DROP TABLE IF EXISTS public.p_produtos_tb;
CREATE TABLE IF NOT EXISTS public.p_produtos_tb
(
    id integer NOT NULL DEFAULT nextval('p_produto_tb_id_seq'::regclass),
    nome character varying(250) COLLATE pg_catalog."default",
    descricao character varying(350) COLLATE pg_catalog."default",
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
    (id ASC NULLS LAST, nome COLLATE pg_catalog."default" ASC NULLS LAST)
    TABLESPACE pg_default;
-------------------------------------------------------------------------------------------------

Criação da tabela v_vendas_tb:

-- Table: public.v_vendas_tb
-- DROP TABLE IF EXISTS public.v_vendas_tb;
CREATE TABLE IF NOT EXISTS public.v_vendas_tb
(
    id integer NOT NULL DEFAULT nextval('"v_vendas.tb_id_seq"'::regclass),
    valor_pago numeric(10,2),
    nome_cliente_id integer,
    CONSTRAINT "v_vendas.tb_pkey" PRIMARY KEY (id),
    CONSTRAINT cliente_id FOREIGN KEY (nome_cliente_id)
        REFERENCES public.c_clientes_tb (id) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
        NOT VALID
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
    id integer NOT NULL DEFAULT nextval('v_detalhes_vendas_tb_id_seq'::regclass),
    venda_id integer,
    produto_id integer,
    quantidade integer,
    CONSTRAINT v_detalhes_vendas_tb_pkey PRIMARY KEY (id),
    CONSTRAINT produto_id FOREIGN KEY (produto_id)
        REFERENCES public.p_produtos_tb (id) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
        NOT VALID,
    CONSTRAINT venda_id FOREIGN KEY (venda_id)
        REFERENCES public.v_vendas_tb (id) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
        NOT VALID
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
    sum(v.valor_pago) AS valortotal
   FROM v_vendas_tb v
     JOIN v_vendas_item_tb vi ON v.id = vi.venda_id
     JOIN p_produtos_tb p ON vi.produto_id = p.id
     JOIN c_clientes_tb c ON v.nome_cliente_id = c.id
  GROUP BY c.nome;
ALTER TABLE public.v_relatorio_vendas
    OWNER TO postgres;
