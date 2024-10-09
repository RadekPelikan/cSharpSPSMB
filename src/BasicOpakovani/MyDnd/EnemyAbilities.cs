using System;

namespace MyDnd
{
    [Flags] 
    enum EnemyAbilities 
    {
        None = 0,
        AttackClose = 1<<0, // 0b 0000 0001
        AttackRange = 1<<1, // 0b 0000 0010
        AttackMagic = 1<<2, // 0b 0000 0100
        Dodge = 1<<3,       // 0b 0000 1000
        Heal = 1<<4         // 0b 0001 0000
    }                       // 0b 0001 0001
}