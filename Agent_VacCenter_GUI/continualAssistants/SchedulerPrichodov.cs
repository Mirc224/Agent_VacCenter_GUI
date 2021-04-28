using OSPABA;
using simulation;
using agents;
using DataStructures;
using System;

namespace continualAssistants
{
    //meta! id="26"
    public class SchedulerPrichodov : Scheduler
    {
        /**
         * Planovac prichodov zakaznikov. Obsahuje generatory pre repreznetaciu jednotlivych pravdepodobnosti ako aj casu skorsieho prichodu. Vygenerovane casy sa 
         * vkladaju do parovacej haldy, z ktorej su behom simulacie vyberane a spravy dalsieho prichodu su pozdrzane.
         */
        private OSPRNG.UniformContinuousRNG _generatorPravdepodobnosti;
        private PairingHeap<double, double> _haldaPrichodov;

        private OSPRNG.UniformContinuousRNG[] _generatoryPrichodov;
        private OSPRNG.UniformContinuousRNG _generatorPravdepodobnostiSpecifickehoPrichodu;
        private OSPRNG.UniformContinuousRNG _generatorPravdepodobnostiDostaveniaVCas;

        public SchedulerPrichodov(int id, Simulation mySim, CommonAgent myAgent) :
            base(id, mySim, myAgent)
        {
        }

        /**
         * Pred replikaciou sa naplni parovacia halda, z ktorej su vyberane casy prichdovo. V pripade ak nie je zvolena moznost skorsich prichodov, je
         * pomocou multipliera generovany cas prichodu pacienta bez skorsieho prichodu. V pripade ak vyjde, ze v nahodnom pokuse, ze dany pacient sa nedostvil
         * tak sa multiplier zvysi o 1 a po tom co dojde k neuspesnemu nahodnemu pokusu je multiplierom vynasobeny casovy rozostup medzi pacientami a je 
         * aktualizovany cas objednania.
         */
        override public void PrepareReplication()
        {
            base.PrepareReplication();
            // Setup component for the next replication
            var sim = MySim as VacCenterSimulation;
            _generatorPravdepodobnosti = new OSPRNG.UniformContinuousRNG(0, 1, sim.GeneratorNasad);
            _haldaPrichodov = new PairingHeap<double, double>();
            MyAgent.VygenerujNepridenych();

            double casObjednania = 0;

            int multiplier = 1;
            double casPrichodu;
            double casovyRozostup = 0;

            if (sim.AktualneParametreSimulacie.SpecialnePrichody)
            {
                double pravdepodobnost;

                _generatorPravdepodobnostiSpecifickehoPrichodu = new OSPRNG.UniformContinuousRNG(0, 1, sim.GeneratorNasad);
                _generatorPravdepodobnostiDostaveniaVCas = new OSPRNG.UniformContinuousRNG(0, 1, sim.GeneratorNasad);
                _generatoryPrichodov = new OSPRNG.UniformContinuousRNG[] { new OSPRNG.UniformContinuousRNG(20 * 60, 60 * 60, sim.GeneratorNasad),
                                                                           new OSPRNG.UniformContinuousRNG(1 * 60, 20 * 60, sim.GeneratorNasad),
                                                                           new OSPRNG.UniformContinuousRNG(60 * 60, 80 * 60, sim.GeneratorNasad),
                                                                           new OSPRNG.UniformContinuousRNG(80 * 60, 240 * 60, sim.GeneratorNasad),
                                                                           };
                for (int i = 0; i < MyAgent.PocetObjednanychPacientov; ++i)
                {
                    multiplier = 1;
                    while (_generatorPravdepodobnosti.Sample() < MyAgent.PocetNepridenychPacientov / (double)MyAgent.PocetObjednanychPacientov)
                    {
                        ++multiplier;
                    }
                    casovyRozostup = multiplier * MyAgent.CasMedziPrichodmi;
                    if (casovyRozostup + casObjednania > sim.CasPrevadzkyVSekundach)
                    {
                        return;
                    }

                    casObjednania += casovyRozostup;

                    if (!(_generatorPravdepodobnostiDostaveniaVCas.Sample() < 0.1))
                    {
                        pravdepodobnost = _generatorPravdepodobnostiSpecifickehoPrichodu.Sample();
                        casPrichodu = DajCasPrichodu(casObjednania, pravdepodobnost);
                    }
                    else
                        casPrichodu = casObjednania;

                    _haldaPrichodov.Insert(casPrichodu, casPrichodu);
                    
                    if (casObjednania > sim.CasPrevadzkyVSekundach)
                        return;
                }
            }
            else
                for (int i = 0; i < MyAgent.PocetObjednanychPacientov; ++i)
                {
                    multiplier = 1;
                    while (_generatorPravdepodobnosti.Sample() < MyAgent.PocetNepridenychPacientov / (double)MyAgent.PocetObjednanychPacientov)
                    {
                        ++multiplier;
                    }
                    casovyRozostup = multiplier * MyAgent.CasMedziPrichodmi;
                    if (casovyRozostup + casObjednania > sim.CasPrevadzkyVSekundach)
                    {
                        return;
                    }
                    casObjednania += casovyRozostup;
                    _haldaPrichodov.Insert(casObjednania, casObjednania);
                    if (casObjednania > sim.CasPrevadzkyVSekundach)
                        return;
                }

        }

        /**
         * Na zaklade casu simulacie a vygenerovanej pravdepodobnosti vrati cas skorsieho prichodu pacienta.
         */
        private double DajCasPrichodu(double casSimulacie, double vygenerovanaPravdepodobnost)
        {
            double casPrichodu;

            if (vygenerovanaPravdepodobnost < 0.4)
            {
                casPrichodu = casSimulacie - _generatoryPrichodov[0].Sample();
            }
            else if (vygenerovanaPravdepodobnost < 0.7)
            {
                casPrichodu = casSimulacie - _generatoryPrichodov[1].Sample();
            }
            else if (vygenerovanaPravdepodobnost < 0.9)
            {
                casPrichodu = casSimulacie - _generatoryPrichodov[2].Sample();
            }
            else
                casPrichodu = casSimulacie - _generatoryPrichodov[3].Sample();

            return Math.Max(casPrichodu, 0);
        }

        //meta! sender="AgentOkolia", id="28", type="Notice"
        public void ProcessNoticeNaplanujPrichod(MessageForm message)
        {
            //int multiplier = 1;
            var sim = MySim as VacCenterSimulation;
            /*while (_generatorPravdepodobnosti.Sample() < MyAgent.PocetNepridenychPacientov / (double)MyAgent.PocetObjednanychPacientov)
            {
                ++multiplier;
				if(multiplier * MyAgent.CasMedziPrichodmi + MySim.CurrentTime > sim.CasPrevadzkyVSekundach)
                {
					MyAgent.Generuj = false;
					return;
                }
            }*/
            if (_haldaPrichodov.Count == 0)
            {
                MyAgent.Generuj = false;
                return;
            }


            message.Code = Mc.NoticePrichodPacienta;
            double casPrichodu = _haldaPrichodov.GetMin();
            //System.Console.WriteLine(casPrichodu - sim.CurrentTime);
            Hold(casPrichodu - sim.CurrentTime, message);
        }

        public void ProcessNoticePrichodPacienta(MessageForm message)
        {
            message.Addressee = MyAgent;
            Notice(message);
        }

        //meta! userInfo="Process messages defined in code", id="0"
        public void ProcessDefault(MessageForm message)
        {
            switch (message.Code)
            {
            }
        }

        //meta! userInfo="Generated code: do not modify", tag="begin"
        override public void ProcessMessage(MessageForm message)
        {
            switch (message.Code)
            {
                case Mc.NoticeNaplanujPrichod:
                    ProcessNoticeNaplanujPrichod(message);
                    break;

                case Mc.NoticePrichodPacienta:
                    ProcessNoticePrichodPacienta(message);
                    break;

                default:
                    ProcessDefault(message);
                    break;
            }
        }
        //meta! tag="end"
        public new AgentOkolia MyAgent
        {
            get
            {
                return (AgentOkolia)base.MyAgent;
            }
        }
    }
}
