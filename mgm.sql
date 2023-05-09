--
-- PostgreSQL database dump
--

-- Dumped from database version 15.2
-- Dumped by pg_dump version 15.2

-- Started on 2023-05-09 17:21:51

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- TOC entry 218 (class 1259 OID 16514)
-- Name: bolgeler; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.bolgeler (
    id integer NOT NULL,
    adi character(100)
);


ALTER TABLE public.bolgeler OWNER TO postgres;

--
-- TOC entry 215 (class 1259 OID 16479)
-- Name: istasyonlar; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.istasyonlar (
    id integer NOT NULL,
    adi character varying(100),
    acilis_tarihi date,
    sehir_id integer
);


ALTER TABLE public.istasyonlar OWNER TO postgres;

--
-- TOC entry 217 (class 1259 OID 16494)
-- Name: olcumler; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.olcumler (
    id integer NOT NULL,
    tarih timestamp without time zone,
    istasyon_id integer,
    parametre_id integer,
    deger double precision
);


ALTER TABLE public.olcumler OWNER TO postgres;

--
-- TOC entry 216 (class 1259 OID 16489)
-- Name: parametreler; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.parametreler (
    id integer NOT NULL,
    ad character varying(50),
    aciklama character varying(255)
);


ALTER TABLE public.parametreler OWNER TO postgres;

--
-- TOC entry 214 (class 1259 OID 16474)
-- Name: sehirler; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.sehirler (
    id integer NOT NULL,
    sehir_adi character varying(100),
    ilce_id integer,
    ilce_adi character varying(100),
    bolge_id integer
);


ALTER TABLE public.sehirler OWNER TO postgres;

--
-- TOC entry 3197 (class 2606 OID 16518)
-- Name: bolgeler bolgeler_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.bolgeler
    ADD CONSTRAINT bolgeler_pkey PRIMARY KEY (id);


--
-- TOC entry 3191 (class 2606 OID 16483)
-- Name: istasyonlar istasyonlar_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.istasyonlar
    ADD CONSTRAINT istasyonlar_pkey PRIMARY KEY (id);


--
-- TOC entry 3195 (class 2606 OID 16498)
-- Name: olcumler olcumler_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.olcumler
    ADD CONSTRAINT olcumler_pkey PRIMARY KEY (id);


--
-- TOC entry 3193 (class 2606 OID 16493)
-- Name: parametreler parametreler_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.parametreler
    ADD CONSTRAINT parametreler_pkey PRIMARY KEY (id);


--
-- TOC entry 3189 (class 2606 OID 16478)
-- Name: sehirler sehirler_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.sehirler
    ADD CONSTRAINT sehirler_pkey PRIMARY KEY (id);


--
-- TOC entry 3198 (class 2606 OID 16519)
-- Name: sehirler bolgeler; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.sehirler
    ADD CONSTRAINT bolgeler FOREIGN KEY (bolge_id) REFERENCES public.bolgeler(id) NOT VALID;


--
-- TOC entry 3199 (class 2606 OID 16484)
-- Name: istasyonlar istasyonlar_sehir_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.istasyonlar
    ADD CONSTRAINT istasyonlar_sehir_id_fkey FOREIGN KEY (sehir_id) REFERENCES public.sehirler(id);


--
-- TOC entry 3200 (class 2606 OID 16499)
-- Name: olcumler olcumler_istasyon_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.olcumler
    ADD CONSTRAINT olcumler_istasyon_id_fkey FOREIGN KEY (istasyon_id) REFERENCES public.istasyonlar(id);


--
-- TOC entry 3201 (class 2606 OID 16504)
-- Name: olcumler olcumler_parametre_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.olcumler
    ADD CONSTRAINT olcumler_parametre_id_fkey FOREIGN KEY (parametre_id) REFERENCES public.parametreler(id);


-- Completed on 2023-05-09 17:21:51

--
-- PostgreSQL database dump complete
--

