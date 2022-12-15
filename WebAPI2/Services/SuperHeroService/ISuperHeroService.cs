using System;
using WebAPI2.Models;

namespace WebAPI2.Services.SuperHeroService
{
	public interface ISuperHeroService
	{
        List<SuperHero>? GetAllHeroes();

        SuperHero? GetSingleHero(int id);

        List<SuperHero> AddHero(SuperHero hero);

        List<SuperHero>? UpdateHero(int id, SuperHero request);

        List<SuperHero>? DeleteHero(int id);
    }
}

