﻿using System.Collections.Generic;
using System.Linq;
using HeroInfrastructure;
using MissionInfrastructure;
using UnityEngine;

namespace Utils
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField]
        private MissionView _missionViewPrefab;
        [SerializeField]
        private HeroView _heroViewPrefab;

        [SerializeField]
        private MapData _mapData;
        [SerializeField]
        private List<HeroBaseData> _allHeroesData;
        [SerializeField]
        private Transform _viewsContainer;

        [SerializeField]
        private MissionPlayer _missionPlayer;

        private HeroesPool _heroesPool;
        private MissionFactory _missionFactory;
        private HeroFactory _heroFactory;
        private GameMap _gameMap;

        private void Awake()
        {
            _gameMap = new GameMap(_mapData);
            _missionFactory = new MissionFactory(_missionViewPrefab);
            _heroFactory = new HeroFactory(_heroViewPrefab);
            _heroesPool = new HeroesPool(_allHeroesData, _heroFactory, _viewsContainer);

            Init();
        }

        private void Init()
        {
            _gameMap.Init(_missionFactory);
            _missionPlayer.Init(_gameMap.GetViews(), _gameMap, _heroesPool);
            _heroesPool.Init();
        }
    }
}