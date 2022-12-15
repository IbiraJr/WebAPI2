using System;
using WebAPI2.Data;

namespace WebAPI2.Services.SuperHeroService
{
    public class SuperHeroService : ISuperHeroService
    {
 
        private readonly DataContext context;
        public SuperHeroService(DataContext context)
        {
            this.context = context;

        }

        public async Task<List<SuperHero>> GetAllHeroes()
        {
            var heroes = await context.SuperHeroes.ToListAsync();
            return heroes;
        }

        public async Task<SuperHero?> GetSingleHero(int id)
        {
            var hero = await context.SuperHeroes.FindAsync(id);
            if (hero is null)
                return null;
            return hero;
        }

        public async Task<List<SuperHero>> AddHero(SuperHero hero)
        {
            context.SuperHeroes.Add(hero);

            await context.SaveChangesAsync();

            return await context.SuperHeroes.ToListAsync();
        }


        public async Task<List<SuperHero>?> UpdateHero(int id, SuperHero request)
        {
            var hero = await context.SuperHeroes.FindAsync(id);
            if (hero is null)
                return null;
            hero.FirstName = request.FirstName;
            hero.LastName = request.LastName;
            hero.Name = request.Name;
            hero.Place = request.Place;

            await context.SaveChangesAsync();

            return await context.SuperHeroes.ToListAsync();
        }

        public async Task<List<SuperHero>?> DeleteHero(int id)
        {
            var hero = await context.SuperHeroes.FindAsync(id);
            if (hero is null)
                return null;

            context.SuperHeroes.Remove(hero);

            await context.SaveChangesAsync();

            return await context.SuperHeroes.ToListAsync();
        }
    }
}

