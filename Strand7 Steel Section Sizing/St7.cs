using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Strand7_Steel_Section_Sizing
{
    public static class St7
    {

        public const int kMaxStrLen = 255;

        // Array Limits
        public const int kMaxEntityTotals = 4;
        public const int kMaxElementNode = 20;
        public const int kMaxBeamResult = 4096;
        public const int kNumBeamSectionData = 20;
        public const int kNumMaterialData = 3;
        public const int kMaxAttributeDoubles = 12;
        public const int kMaxAttributeLogicals = 6;
        public const int kMaxAttributeLongint = 6;
        public const int kLastUnit = 6;

        // Unit Positions
        public const int ipLENGTHU = 0;
        public const int ipFORCEU = 1;
        public const int ipSTRESSU = 2;
        public const int ipMASSU = 3;
        public const int ipTEMPERU = 4;
        public const int ipENERGYU = 5;

        // Unit Types - LENGTH
        public const int luMETRE = 0;
        public const int luCENTIMETRE = 1;
        public const int luMILLIMETRE = 2;
        public const int luFOOT = 3;
        public const int luINCH = 4;

        // Unit Types - FORCE
        public const int fuNEWTON = 0;
        public const int fuKILONEWTON = 1;
        public const int fuMEGANEWTON = 2;
        public const int fuKILOFORCE = 3;
        public const int fuPOUNDFORCE = 4;
        public const int fuTONNEFORCE = 5;
        public const int fuKIPFORCE = 6;

        // Unit Types - STRESS
        public const int suPASCAL = 0;
        public const int suKILOPASCAL = 1;
        public const int suMEGAPASCAL = 2;
        public const int suKSCm = 3;
        public const int suPSI = 4;
        public const int suKSI = 5;
        public const int suPSF = 6;

        // Unit Types - MASS
        public const int muKILOGRAM = 0;
        public const int muTONNE = 1;
        public const int muGRAM = 2;
        public const int muPOUND = 3;
        public const int muSLUG = 4;

        // Unit Types - TEMPERATURE
        public const int tuCELSIUS = 0;
        public const int tuFAHRENHEIT = 1;
        public const int tuKELVIN = 2;

        // Unit Types - ENERGY
        public const int euJOULE = 0;
        public const int euBTU = 1;
        public const int euFTLBF = 2;
        public const int euCALORIE = 3;

        // Unit Types - TIME
        public const int tuMilliSec = 0;
        public const int tuSec = 1;
        public const int tuMin = 2;
        public const int tuHour = 3;
        public const int tuDay = 4;

        // Entity Types
        public const int tyNULL = -1;
        public const int tyNODE = 0;
        public const int tyBEAM = 1;
        public const int tyPLATE = 2;
        public const int tyBRICK = 3;
        public const int tyLINK = 4;
        public const int tyVERTEX = 5;
        public const int tyGEOMETRYEDGE = 6;
        public const int tyGEOMETRYFACE = 7;
        public const int tyLOADPATH = 8;

        // Link Types
        public const int ilMasterSlaveLink = 1;
        public const int ilSectorSymmetryLink = 2;
        public const int ilCouplingLink = 3;
        public const int ilPinnedLink = 4;
        public const int ilRigidLink = 5;
        public const int ilShrinkLink = 6;
        public const int ilTwoPointLink = 7;
        public const int ilAttachmentLink = 8;
        public const int ilMultiPointLink = 9;

        // Master-Slave Link
        public const int msFree = 0;
        public const int msFix = 1;
        public const int msFixNegate = -1;

        // Coupling, Attachment and Multi-Point Links
        public const int cpTranslational = 1;
        public const int cpRotational = 2;
        public const int cpBoth = 3;

        // Rigid Link
        public const int rgPlaneXYZ = 0;
        public const int rgPlaneXY = 1;
        public const int rgPlaneYZ = 2;
        public const int rgPlaneZX = 3;

        // 2-Point Link
        public const int ipTwoPointDOF1 = 0;
        public const int ipTwoPointDOF2 = 1;
        public const int ipTwoPointUCS1 = 2;
        public const int ipTwoPointUCS2 = 3;
        public const int ipTwoPointC0 = 0;
        public const int ipTwoPointC1 = 1;
        public const int ipTwoPointC2 = 2;

        // Attachment Link
        public const int ipAttachmentElType = 0;
        public const int ipAttachmentElNum = 1;
        public const int ipAttachmentBrickFaceNum = 2;
        public const int ipAttachmentCouple = 3;

        // Multi-Point Link
        public const int mpInterpolatedFactors = 1;
        public const int mpUserFactors = 2;

        // Node Temperature Types
        public const int tReferenceTemperature = 0;
        public const int tFixedTemperature = 1;
        public const int tInitialTemperature = 2;
        public const int tTableTemperature = 3;

        // Beam End Release Constants
        public const int kBeamEndRelReleased = 0;
        public const int kBeamEndRelFixed = 1;
        public const int kBeamEndRelPartial = 2;

        // Property Types
        public const int ptBEAMPROP = 1;
        public const int ptPLATEPROP = 2;
        public const int ptBRICKPROP = 3;
        public const int ptPLYPROP = 4;

        // Property Totals
        public const int ipBeamPropTotal = 0;
        public const int ipPlatePropTotal = 1;
        public const int ipBrickPropTotal = 2;
        public const int ipPlyPropTotal = 3;

        // Alpha Temperature Types
        public const int kIntegratedAlpha = 0;
        public const int kInstantAlpha = 1;

        // Sampling Positions
        public const int AtCentroid = 0;
        public const int AtGaussPoints = 1;
        public const int AtNodesAverageNever = 2;
        public const int AtNodesAverageAll = 3;
        public const int AtNodesAverageSame = 4;

        // Beam Types
        public const int kBeamTypeNull = 0;
        public const int kBeamTypeSpring = 1;
        public const int kBeamTypeCable = 2;
        public const int kBeamTypeTruss = 3;
        public const int kBeamTypeCutoff = 4;
        public const int kBeamTypeContact = 5;
        public const int kBeamTypeBeam = 6;
        public const int kBeamTypeUser = 7;
        public const int kBeamTypePipe = 8;
        public const int kBeamTypeConnection = 9;

        // Contact Types
        public const int kZeroGapContact = 0;
        public const int kNormalContact = 1;
        public const int kTensionContact = 2;
        public const int kTakeupContact = 3;

        // Contact Sub Types
        public const int kTensionTakeup = 0;
        public const int kCompressionTakeup = 1;

        // Cutoff Types
        public const int kBrittleGap = 0;
        public const int kDuctileGap = 1;

        // Contact Parameters Positions - Integers
        public const int ipContactType = 0;
        public const int ipDynamicStiffness = 1;
        public const int ipUseInFirstIteration = 2;
        public const int ipUpdateDirection = 3;
        public const int ipContactSubType = 4;
        public const int ipFrictionYieldType = 5;
        public const int ipFrictionModel = 6;
        public const int ipTensionLateralStiffness = 7;

        // Contact Parameters Positions - Doubles
        public const int ipContactStiffness = 0;
        public const int ipFrictionC1 = 1;
        public const int ipFrictionC2 = 2;
        public const int ipContactMaxTension = 3;

        // CutoffBar Parameter Positions
        public const int ipCutoffType = 0;
        public const int ipKeepMass = 1;

        // Library Types
        public const int lbMaterial = 0;
        public const int lbBeamSection = 1;
        public const int lbComposite = 2;
        public const int lbReinforcementLayout = 3;
        public const int lbCreepDefinition = 4;
        public const int lbLoadPathTemplate = 5;

        // Beam Section Types
        public const int kNullSection = 0;
        public const int kCircularSolid = 1;
        public const int kCircularHollow = 2;
        public const int kSquareSolid = 3;
        public const int kSquareHollow = 4;
        public const int kLipChannel = 5;
        public const int kTopHatChannel = 6;
        public const int kISection = 7;
        public const int kTSection = 8;
        public const int kLSection = 9;
        public const int kZSection = 10;
        public const int kUserSection = 11;
        public const int kTrapezoidSolid = 12;
        public const int kTrapezoidHollow = 13;
        public const int kTriangleSolid = 14;
        public const int kTriangleHollow = 15;
        public const int kCruciform = 16;

        // Beam Mirror Types
        public const int kMirrorNone = 0;
        public const int kMirrorTop = 1;
        public const int kMirrorBot = 2;
        public const int kMirrorLeft = 3;
        public const int kMirrorRight = 4;
        public const int kMirrorLeftAndTop = 5;
        public const int kMirrorLeftAndBot = 6;
        public const int kMirrorRightAndTop = 7;
        public const int kMirrorRightAndBot = 8;
        public const int kMirrorLeftTopOnly = 9;
        public const int kMirrorLeftBotOnly = 10;
        public const int kMirrorRightTopOnly = 11;
        public const int kMirrorRightBotOnly = 12;

        // Beam Section Positions
        public const int ipAREA = 0;
        public const int ipI11 = 1;
        public const int ipI22 = 2;
        public const int ipJ = 3;
        public const int ipSL1 = 4;
        public const int ipSL2 = 5;
        public const int ipSA1 = 6;
        public const int ipSA2 = 7;
        public const int ipXBAR = 8;
        public const int ipYBAR = 9;
        public const int ipANGLE = 10;
        public const int ipD1 = 11;
        public const int ipD2 = 12;
        public const int ipD3 = 13;
        public const int ipT1 = 14;
        public const int ipT2 = 15;
        public const int ipT3 = 16;
        public const int ipGapA = 17;
        public const int ipGapB = 18;

        // Beam Load Types
        public const int kMaxDLPerBeam = 64;
        public const int kConstantDL = 0;
        public const int kLinearDL = 1;
        public const int kTriangularDL = 2;
        public const int kThreePoint0DL = 3;
        public const int kThreePoint1DL = 4;
        public const int kTrapezoidalDL = 5;

        // Plate Load Patch Types
        public const int ptAuto4 = 0;
        public const int ptAuto3 = 1;
        public const int ptAuto2 = 2;
        public const int ptAuto1 = 3;
        public const int ptAngleSplit = 4;
        public const int ptManual = 5;

        // Plate Types
        public const int kPlateTypeNull = 0;
        public const int kPlateTypePlaneStress = 1;
        public const int kPlateTypePlaneStrain = 2;
        public const int kPlateTypeAxisymmetric = 3;
        public const int kPlateTypePlateShell = 4;
        public const int kPlateTypeShearPanel = 5;
        public const int kPlateTypeMembrane = 6;
        public const int kPlateTypeLoadPatch = 7;

        // Geometry Surface Types
        public const int suPlane = 0;
        public const int suSphere = 1;
        public const int suTorus = 2;
        public const int suCone = 3;
        public const int suBSpline = 4;
        public const int suRotSur = 5;
        public const int suPipeSur = 6;
        public const int suSumSur = 7;
        public const int suTabCyl = 8;
        public const int suRuleSur = 9;
        public const int suCubicSpline = 10;

        // Plate Section Positions
        public const int ipTHICKM = 0;
        public const int ipTHICKB = 1;

        // Material Types
        public const int kMaterialTypeNull = 0;
        public const int kMaterialTypeIsotropic = 1;
        public const int kMaterialTypeOrthotropic = 2;
        public const int kMaterialTypeAnisotropic = 3;
        public const int kMaterialTypeRubber = 4;
        public const int kMaterialTypeSoil = 5;
        public const int kMaterialTypeLaminate = 6;
        public const int kMaterialTypeUserDefined = 7;
        public const int kMaterialTypePly = 8;
        public const int kMaterialTypeFluid = 10;

        // Yield Criteria
        public const int ycTresca = 0;
        public const int ycVonMises = 1;
        public const int ycMaxStress = 2;
        public const int ycMohrCoulomb = 3;
        public const int ycDruckerPrager = 4;

        // Nonlinear Types
        public const int ntNonlinElastic = 0;
        public const int ntElastoPlastic = 1;

        // Rubber Types
        public const int kNeoHookean = 1;
        public const int kMooneyRivlin = 2;
        public const int kGeneralisedMooneyRivlin = 3;
        public const int kOgden = 4;

        // Material Positions
        public const int ipModulus = 0;
        public const int ipPoisson = 1;
        public const int ipDensity = 2;

        // Node Result Types - Old convention
        public const int kNodeDisp = 1;
        public const int kNodeVel = 2;
        public const int kNodeAcc = 3;
        public const int kNodePhase = 4;
        public const int kNodeReact = 5;
        public const int kNodeTemp = 6;
        public const int kNodeFlux = 7;
        public const int kNodeInfluence = 1;

        // Node Result Types
        public const int rtNodeDisp = 1;
        public const int rtNodeVel = 2;
        public const int rtNodeAcc = 3;
        public const int rtNodePhase = 4;
        public const int rtNodeReact = 5;
        public const int rtNodeTemp = 6;
        public const int rtNodeFlux = 7;
        public const int rtNodeInfluence = 1;

        // Beam Result Types
        public const int rtBeamForce = 1;
        public const int rtBeamStrain = 2;
        public const int rtBeamStress = 3;
        public const int rtBeamTRelease = 4;
        public const int rtBeamRRelease = 5;
        public const int rtBeamCableXYZ = 6;
        public const int rtBeamFlux = 8;
        public const int rtBeamGradient = 9;
        public const int rtBeamCreepStrain = 10;
        public const int rtBeamEnergy = 11;
        public const int rtBeamDisp = 12;
        public const int rtBeamNodeReact = 13;

        // Beam Result Quantities - BEAMFORCE - Local and Principal
        public const int ipBeamSF1 = 0;
        public const int ipBeamBM1 = 1;
        public const int ipBeamSF2 = 2;
        public const int ipBeamBM2 = 3;
        public const int ipBeamAxialF = 4;
        public const int ipBeamTorque = 5;

        // Beam Result Quantities - BEAMFORCE - Global
        public const int ipBeamFX = 0;
        public const int ipBeamMX = 1;
        public const int ipBeamFY = 2;
        public const int ipBeamMY = 3;
        public const int ipBeamFZ = 4;
        public const int ipBeamMZ = 5;

        // Beam Result Quantities - BEAMSTRESS
        public const int ipMinFibreStress = 0;
        public const int ipMaxFibreStress = 1;
        public const int ipMaxShearStress1 = 2;
        public const int ipMaxShearStress2 = 3;
        public const int ipAvShearStress1 = 4;
        public const int ipAvShearStress2 = 5;
        public const int ipTorqueStress = 6;
        public const int ipMinPrincipalStress = 7;
        public const int ipMaxPrincipalStress = 8;
        public const int ipMinPipeHoopStress = 9;
        public const int ipMaxPipeHoopStress = 10;
        public const int ipMinAxialStress = 11;
        public const int ipMaxAxialStress = 12;
        public const int ipMinBendingStress1 = 13;
        public const int ipMaxBendingStress1 = 14;
        public const int ipMinBendingStress2 = 15;
        public const int ipMaxBendingStress2 = 16;
        public const int ipYieldRatio = 17;

        // Beam Result Quantities - BEAMFLUXGRAD
        public const int ipBeamFlux = 0;
        public const int ipBeamTempGradient = 1;

        // Beam Result Quantities - BEAMSTRAIN
        public const int ipAxialStrain = 0;
        public const int ipCurvature1 = 1;
        public const int ipCurvature2 = 2;
        public const int ipTwist = 3;

        // Beam Result Quantities - BEAMRELEASE
        public const int ipRelEnd1Dir1 = 0;
        public const int ipRelEnd1Dir2 = 1;
        public const int ipRelEnd1Dir3 = 2;
        public const int ipRelEnd2Dir1 = 3;
        public const int ipRelEnd2Dir2 = 4;
        public const int ipRelEnd2Dir3 = 5;

        // Beam Result Quantities - BEAMENERGY
        public const int ipBeamEnergyStored = 0;
        public const int ipBeamEnergySpent = 1;

        // Plate Result Types
        public const int rtPlateStress = 1;
        public const int rtPlateStrain = 2;
        public const int rtPlateEnergy = 3;
        public const int rtPlateForce = 4;
        public const int rtPlateMoment = 5;
        public const int rtPlateCurvature = 6;
        public const int rtPlatePlyStress = 7;
        public const int rtPlatePlyStrain = 8;
        public const int rtPlatePlyReserve = 9;
        public const int rtPlateFlux = 10;
        public const int rtPlateGradient = 11;
        public const int rtPlateReoDesign = 12;
        public const int rtPlateCreepStrain = 13;
        public const int rtPlateSoil = 14;
        public const int rtPlateUser = 15;
        public const int rtPlateNodeReact = 16;
        public const int rtPlateNodeDisp = 17;

        // Plate Surface Definition
        public const int psPlateMidPlane = 0;
        public const int psPlateZMinus = 1;
        public const int psPlateZPlus = 2;

        // Brick Result Types
        public const int rtBrickStress = 1;
        public const int rtBrickStrain = 2;
        public const int rtBrickEnergy = 3;
        public const int rtBrickFlux = 4;
        public const int rtBrickGradient = 5;
        public const int rtBrickCreepStrain = 6;
        public const int rtBrickSoil = 7;
        public const int rtBrickUser = 8;
        public const int rtBrickNodeReact = 9;
        public const int rtBrickNodeDisp = 10;

        // Beam Result Sub Types
        public const int stBeamLocal = 0;
        public const int stBeamPrincipal = -1;
        public const int stBeamGlobal = -2;

        // Plate Result Sub Types
        public const int stPlateLocal = 0;
        public const int stPlateGlobal = -1;
        public const int stPlateCombined = -2;
        public const int stPlateSupport = -3;
        public const int stPlateDevLocal = -4;
        public const int stPlateDevGlobal = -5;
        public const int stPlateDevCombined = -6;

        // Brick Result Sub Types
        public const int stBrickLocal = 0;
        public const int stBrickGlobal = -1;
        public const int stBrickCombined = -2;
        public const int stBrickSupport = -3;
        public const int stBrickDevLocal = -4;
        public const int stBrickDevGlobal = -5;
        public const int stBrickDevCombined = -6;

        // Plate/Brick Result Sub Types (Undocumented)
        public const int stLOCAL = 0;
        public const int stGLOBAL = 1;
        public const int stUCS = 2;
        public const int stCOMBINED = 3;

        // PLATESTRESS, PLATESTRAIN, PLATECREEPSTRAIN, PLATEMOMENT, PLATECURVATURE, PLATEFORCE results for STLOCAL
        public const int ipPlateLocalxx = 0;
        public const int ipPlateLocalyy = 1;
        public const int ipPlateLocalzz = 2;
        public const int ipPlateLocalxy = 3;
        public const int ipPlateLocalyz = 4;
        public const int ipPlateLocalzx = 5;
        public const int ipPlateLocalxz = 5;
        public const int ipPlateLocalMean = 0;
        public const int ipPlateLocalDevxx = 1;
        public const int ipPlateLocalDevyy = 2;
        public const int ipPlateEdgeSupport = 0;
        public const int ipPlateFaceSupport = 1;

        // PLATESTRESS, PLATESTRAIN, PLATECREEPSTRAIN, PLATEMOMENT, PLATECURVATURE, PLATEFORCE results for STGLOBAL (NOT AXISYMMETRIC)
        public const int ipPlateGlobalXX = 0;
        public const int ipPlateGlobalYY = 1;
        public const int ipPlateGlobalZZ = 2;
        public const int ipPlateGlobalXY = 3;
        public const int ipPlateGlobalYZ = 4;
        public const int ipPlateGlobalZX = 5;
        public const int ipPlateGlobalMean = 0;
        public const int ipPlateGlobalDevXX = 1;
        public const int ipPlateGlobalDevYY = 2;
        public const int ipPlateGlobalDevZZ = 3;

        // PLATESTRESS, PLATESTRAIN, PLATECREEPSTRAIN, PLATEMOMENT, PLATECURVATURE, PLATEFORCE results for STUCS
        public const int ipPlateUCSXX = 0;
        public const int ipPlateUCSYY = 1;
        public const int ipPlateUCSZZ = 2;
        public const int ipPlateUCSXY = 3;
        public const int ipPlateUCSYZ = 4;
        public const int ipPlateUCSZX = 5;

        // PLATESTRESS, PLATESTRAIN, PLATECREEPSTRAIN, PLATEFORCE, PLATEMOMENT, PLATECURVATURE results for STCOMBINED (NOT AXISYMMETRIC)
        public const int ipPlateCombPrincipal11 = 0;
        public const int ipPlateCombPrincipal22 = 1;
        public const int ipPlateCombPrincipalAngle = 3;
        public const int ipPlateCombVonMises = 4;
        public const int ipPlateCombTresca = 5;
        public const int ipPlateCombMohrCoulomb = 6;
        public const int ipPlateCombDruckerPrager = 7;
        public const int ipPlateCombPlasticStrain = 6;
        public const int ipPlateCombCreepEffRate = 6;
        public const int ipPlateCombCreepShrinkage = 7;
        public const int ipPlateCombYieldIndex = 8;
        public const int ipPlateCombMean = 0;
        public const int ipPlateCombDev11 = 1;
        public const int ipPlateCombDev22 = 2;

        // PLATESTRESS, PLATESTRAIN, PLATECREEPSTRAIN results for STGLOBAL (AXISYMMETRIC)
        public const int ipPlateAxiGlobalRR = 0;
        public const int ipPlateAxiGlobalZZ = 1;
        public const int ipPlateAxiGlobalTT = 2;
        public const int ipPlateAxiGlobalRZ = 3;
        public const int ipPlateAxiGlobalMean = 0;
        public const int ipPlateAxiGlobalDevRR = 1;
        public const int ipPlateAxiGlobalDevZZ = 2;
        public const int ipPlateAxiGlobalDevTT = 3;

        // PLATESTRESS, PLATESTRAIN, PLATECREEPSTRAIN results for STCOMBINED (AXISYMMETRIC)
        public const int ipPlateAxiCombPrincipal11 = 0;
        public const int ipPlateAxiCombPrincipal22 = 1;
        public const int ipPlateAxiCombPrincipal33 = 2;
        public const int ipPlateAxiCombVonMises = 4;
        public const int ipPlateAxiCombTresca = 5;
        public const int ipPlateAxiCombMohrCoulomb = 6;
        public const int ipPlateAxiCombDruckerPrager = 7;
        public const int ipPlateAxiCombPlasticStrain = 6;
        public const int ipPlateAxiCombCreepEffRate = 5;
        public const int ipPlateAxiCombCreepShrinkage = 7;
        public const int ipPlateAxiCombYieldIndex = 8;
        public const int ipPlateAxiCombMean = 0;
        public const int ipPlateAxiCombDev11 = 1;
        public const int ipPlateAxiCombDev22 = 2;
        public const int ipPlateAxiCombDev33 = 3;

        // PLATEPLYSTRESS
        public const int ipPlyStress11 = 0;
        public const int ipPlyStress22 = 1;
        public const int ipPlyStress12 = 3;
        public const int ipPlyILSx = 4;
        public const int ipPlyILSy = 5;

        // PLATEPLYSTRAIN
        public const int ipPlyStrain11 = 0;
        public const int ipPlyStrain22 = 1;
        public const int ipPlyStrain12 = 3;

        // PLATEPLYRESERVE
        public const int ipPlyMaxStress = 0;
        public const int ipPlyMaxStrain = 1;
        public const int ipPlyTsaiHill = 2;
        public const int ipPlyModTsaiWu = 3;
        public const int ipPlyHoffman = 4;
        public const int ipPlyInterlam = 5;

        // PLATESOIL
        public const int ipPlateSoilTotalPorePressure = 0;
        public const int ipPlateSoilExcessPorePressure = 1;
        public const int ipPlateSoilOCRIndex = 2;
        public const int ipPlateSoilStateIndex = 3;
        public const int ipPlateSoilVoidRatio = 4;

        // PLATEFLUX, PLATEGRADIENT results for STLOCAL
        public const int ipPlateFluxLocalx = 0;
        public const int ipPlateFluxLocaly = 1;
        public const int ipPlateFluxLocalxy = 2;

        // PLATEFLUX, PLATEGRADIENT results for STGLOBAL
        public const int ipPlateFluxGlobalX = 0;
        public const int ipPlateFluxGlobalY = 1;
        public const int ipPlateFluxGlobalZ = 2;
        public const int ipPlateFluxGlobalXY = 3;
        public const int ipPlateFluxGlobalYZ = 4;
        public const int ipPlateFluxGlobalZX = 5;
        public const int ipPlateFluxGlobalSRSS = 6;

        // PLATEFLUX, PLATEGRADIENT results for STUCS
        public const int ipPlateFluxUCSX = 0;
        public const int ipPlateFluxUCSY = 1;
        public const int ipPlateFluxUCSZ = 2;
        public const int ipPlateFluxUCSXY = 3;
        public const int ipPlateFluxUCSYZ = 4;
        public const int ipPlateFluxUCSZX = 5;
        public const int ipPlateFluxUCSSRSS = 6;

        // PLATEREODESIGN
        public const int ipPlateRCWoodArmerMoment = 0;
        public const int ipPlateRCWoodArmerForce = 1;
        public const int ipPlateRCSteelArea = 2;
        public const int ipPlateRCSteelAreaLessBase = 3;
        public const int ipPlateRCSteelStress = 4;
        public const int ipPlateRCConcreteStrain = 5;
        public const int ipPlateRCBlockRatio = 6;

        // PLATENODEREACT
        public const int ipPlateNodeReactFX = 0;
        public const int ipPlateNodeReactFY = 1;
        public const int ipPlateNodeReactFZ = 2;
        public const int ipPlateNodeReactMX = 3;
        public const int ipPlateNodeReactMY = 4;
        public const int ipPlateNodeReactMZ = 5;

        // PLATEENERGY
        public const int ipPlateEnergyStored = 0;
        public const int ipPlateEnergySpent = 1;

        // BRICKSTRESS, BRICKSTRAIN, BRICKCREEPSTRAIN results for STLOCAL
        public const int ipBrickLocalxx = 0;
        public const int ipBrickLocalyy = 1;
        public const int ipBrickLocalzz = 2;
        public const int ipBrickLocalxy = 3;
        public const int ipBrickLocalyz = 4;
        public const int ipBrickLocalzx = 5;
        public const int ipBrickLocalMean = 0;
        public const int ipBrickLocalDevxx = 1;
        public const int ipBrickLocalDevyy = 2;
        public const int ipBrickLocalDevzz = 3;
        public const int ipBrickFaceSupport = 0;

        // BRICKSTRESS, BRICKSTRAIN, BRICKCREEPSTRAIN results for STGLOBAL
        public const int ipBrickGlobalXX = 0;
        public const int ipBrickGlobalYY = 1;
        public const int ipBrickGlobalZZ = 2;
        public const int ipBrickGlobalXY = 3;
        public const int ipBrickGlobalYZ = 4;
        public const int ipBrickGlobalZX = 5;
        public const int ipBrickGlobalMean = 0;
        public const int ipBrickGlobalDevXX = 1;
        public const int ipBrickGlobalDevYY = 2;
        public const int ipBrickGlobalDevZZ = 3;

        // BRICKSTRESS, BRICKSTRAIN, BRICKCREEPSTRAIN results for STUCS
        public const int ipBrickUCSXX = 0;
        public const int ipBrickUCSYY = 1;
        public const int ipBrickUCSZZ = 2;
        public const int ipBrickUCSXY = 3;
        public const int ipBrickUCSYZ = 4;
        public const int ipBrickUCSZX = 5;

        // BRICKSTRESS, BRICKSTRAIN, BRICKCREEPSTRAIN results for STCOMBINED
        public const int ipBrickCombPrincipal11 = 0;
        public const int ipBrickCombPrincipal22 = 1;
        public const int ipBrickCombPrincipal33 = 2;
        public const int ipBrickCombVonMises = 3;
        public const int ipBrickCombTresca = 4;
        public const int ipBrickCombMohrCoulomb = 5;
        public const int ipBrickCombDruckerPrager = 6;
        public const int ipBrickCombPlasticStrain = 6;
        public const int ipBrickCombCreepEffRate = 6;
        public const int ipBrickCombCreepShrinkage = 7;
        public const int ipBrickCombYieldIndex = 8;
        public const int ipBrickCombMean = 0;
        public const int ipBrickCombDev11 = 1;
        public const int ipBrickCombDev22 = 2;
        public const int ipBrickCombDev33 = 3;

        // BRICKSOIL
        public const int ipBrickSoilTotalPorePressure = 0;
        public const int ipBrickSoilExcessPorePressure = 1;
        public const int ipBrickSoilOCRIndex = 2;
        public const int ipBrickSoilStateIndex = 3;
        public const int ipBrickSoilVoidRatio = 4;

        // BRICKFLUX, BRICKGRADIENT results for STLOCAL
        public const int ipBrickFluxLocalx = 0;
        public const int ipBrickFluxLocaly = 1;
        public const int ipBrickFluxLocalz = 2;
        public const int ipBrickFluxLocalxy = 3;
        public const int ipBrickFluxLocalyz = 4;
        public const int ipBrickFluxLocalzx = 5;
        public const int ipBrickFluxLocalRMS = 6;

        // BRICKFLUX, BRICKGRADIENT results for STGLOBAL
        public const int ipBrickFluxGlobalX = 0;
        public const int ipBrickFluxGlobalY = 1;
        public const int ipBrickFluxGlobalZ = 2;
        public const int ipBrickFluxGlobalXY = 3;
        public const int ipBrickFluxGlobalYZ = 4;
        public const int ipBrickFluxGlobalZX = 5;
        public const int ipBrickFluxGlobalRMS = 6;

        // BRICKFLUX, BRICKGRADIENT results for STUCS
        public const int ipBrickFluxUCSX = 0;
        public const int ipBrickFluxUCSY = 1;
        public const int ipBrickFluxUCSZ = 2;
        public const int ipBrickFluxUCSXY = 3;
        public const int ipBrickFluxUCSYZ = 4;
        public const int ipBrickFluxUCSZX = 5;
        public const int ipBrickFluxUCSRMS = 6;

        // BRICKNODEREACT
        public const int ipBrickNodeReactFX = 0;
        public const int ipBrickNodeReactFY = 1;
        public const int ipBrickNodeReactFZ = 2;

        // BRICKENERGY
        public const int ipBrickEnergyStored = 0;
        public const int ipBrickEnergySpent = 1;

        // MODAL RESULTS NFA
        public const int ipFrequencyNFA = 0;
        public const int ipModalMassNFA = 1;
        public const int ipModalStiffNFA = 2;
        public const int ipModalDampNFA = 3;
        public const int ipModalTMassP1 = 4;
        public const int ipModalTMassP2 = 5;
        public const int ipModalTMassP3 = 6;
        public const int ipModalRMassP1 = 7;
        public const int ipModalRMassP2 = 8;
        public const int ipModalRMassP3 = 9;

        // INERTIA RELIEF RESULTS
        public const int ipMassXIRA = 0;
        public const int ipMassYIRA = 1;
        public const int ipMassZIRA = 2;
        public const int ipXcIRA = 3;
        public const int ipYcIRA = 4;
        public const int ipZcIRA = 5;
        public const int ipAccXIRA = 6;
        public const int ipAccYIRA = 7;
        public const int ipAccZIRA = 8;
        public const int ipAngAccXIRA = 9;
        public const int ipAngAccYIRA = 10;
        public const int ipAngAccZIRA = 11;

        // UCS Types
        public const int UCSCartesian = 0;
        public const int UCSCylindrical = 1;
        public const int UCSSpherical = 2;
        public const int UCSToroidal = 3;

        // Matrix Types
        public const int mtCompliance = 1;
        public const int mtStiffness = 2;

        // Node/Vertex Attribute Types
        public const int ATTRFreedom = 1;
        public const int ATTRForce = 2;
        public const int ATTRMoment = 3;
        public const int ATTRTemperature = 4;
        public const int ATTRMTranslation = 5;
        public const int ATTRMRotation = 6;
        public const int ATTRKTranslation = 7;
        public const int ATTRKRotation = 8;
        public const int ATTRDamping = 9;
        public const int ATTRNSMass = 10;
        public const int ATTRNodeInfluence = 11;
        public const int ATTRNodeHeatSource = 12;
        public const int ATTRNodeVelocity = 13;
        public const int ATTRNodeAcceleration = 14;

        // Vertex Types
        public const int vtFree = 1;
        public const int vtFixed = 2;

        // Beam Attribute Types
        public const int ATTRBeamAngle = 21;
        public const int ATTRBeamOffset = 22;
        public const int ATTRBeamTEndRelease = 23;
        public const int ATTRBeamREndRelease = 24;
        public const int ATTRBeamSupport = 25;
        public const int ATTRBeamPreTension = 26;
        public const int ATTRCableFreeLength = 27;
        public const int ATTRBeamDLL = 28;
        public const int ATTRBeamDLG = 29;
        public const int ATTRBeamCFL = 30;
        public const int ATTRBeamCFG = 31;
        public const int ATTRBeamCML = 32;
        public const int ATTRBeamCMG = 33;
        public const int ATTRBeamTempGradient = 34;
        public const int ATTRBeamConvection = 35;
        public const int ATTRBeamRadiation = 36;
        public const int ATTRBeamFlux = 37;
        public const int ATTRBeamHeatSource = 38;
        public const int ATTRBeamRadius = 39;
        public const int ATTRPipePressure = 40;
        public const int ATTRBeamNSMass = 41;
        public const int ATTRPipeTemperature = 42;
        public const int ATTRBeamDML = 44;
        public const int ATTRBeamStringGroup = 45;
        public const int ATTRBeamTaper = 92;
        public const int ATTRBeamInfluence = 93;
        public const int ATTRBeamSectionFactor = 94;
        public const int ATTRBeamCreepLoadingAge = 95;
        public const int ATTRBeamEndAttachment = 96;
        public const int ATTRBeamConnectionUCS = 97;
        public const int ATTRBeamStageProperty = 98;

        // Plate/Edge/Face Attribute Types
        public const int ATTRPlateAngle = 51;
        public const int ATTRPlateOffset = 52;
        public const int ATTRPlatePreLoad = 53;
        public const int ATTRPlateFacePressure = 54;
        public const int ATTRPlateFaceShear = 55;
        public const int ATTRPlateEdgePressure = 56;
        public const int ATTRPlateEdgeShear = 57;
        public const int ATTRPlateEdgeNormalShear = 58;
        public const int ATTRPlateTempGradient = 59;
        public const int ATTRPlateEdgeSupport = 60;
        public const int ATTRPlateFaceSupport = 61;
        public const int ATTRPlateEdgeConvection = 62;
        public const int ATTRPlateEdgeRadiation = 63;
        public const int ATTRPlateFlux = 64;
        public const int ATTRPlateHeatSource = 65;
        public const int ATTRPlateGlobalPressure = 66;
        public const int ATTRPlateEdgeRelease = 67;
        public const int ATTRPlateThickness = 69;
        public const int ATTRPlateNSMass = 70;
        public const int ATTRLoadPatch = 71;
        public const int ATTRPlatePointForce = 99;
        public const int ATTRPlatePointMoment = 100;
        public const int ATTRPlateFaceConvection = 101;
        public const int ATTRPlateFaceRadiation = 102;
        public const int ATTRPlateInfluence = 103;
        public const int ATTRPlateSoilStress = 104;
        public const int ATTRPlateSoilRatio = 105;
        public const int ATTRPlateCreepLoadingAge = 106;
        public const int ATTRPlateEdgeAttachment = 107;
        public const int ATTRPlateFaceAttachment = 108;
        public const int ATTRPlateStageProperty = 109;

        // Edge Types
        public const int etInterpolated = 0;
        public const int etNonInterpolated = 1;

        // Plate/Face Global Pressure Projection Options
        public const int pfNone = 0;
        public const int pfProjResultant = 1;
        public const int pfProjComponents = 2;

        // Brick Attribute Types
        public const int ATTRBrickPressure = 81;
        public const int ATTRBrickShear = 82;
        public const int ATTRBrickFaceFoundation = 83;
        public const int ATTRBrickConvection = 84;
        public const int ATTRBrickRadiation = 85;
        public const int ATTRBrickFlux = 86;
        public const int ATTRBrickHeatSource = 87;
        public const int ATTRBrickGlobalPressure = 88;
        public const int ATTRBrickNSMass = 89;
        public const int ATTRBrickLocalAxes = 90;
        public const int ATTRBrickPreLoad = 91;
        public const int ATTRBrickPointForce = 110;
        public const int ATTRBrickInfluence = 111;
        public const int ATTRBrickSoilStress = 112;
        public const int ATTRBrickSoilRatio = 113;
        public const int ATTRBrickCreepLoadingAge = 114;
        public const int ATTRBrickFaceAttachment = 115;
        public const int ATTRBrickStageProperty = 116;

        // Titles
        public const int TITLEModel = 0;
        public const int TITLEProject = 1;
        public const int TITLEReference = 2;
        public const int TITLEAuthor = 3;
        public const int TITLECreated = 4;
        public const int TITLEModified = 5;

        // Table Types
        public const int ttVsTime = 1;
        public const int ttVsTemperature = 2;
        public const int ttVsFrequency = 3;
        public const int ttStressStrain = 4;
        public const int ttForceDisplacement = 5;
        public const int ttMomentCurvature = 6;
        public const int ttMomentRotation = 8;
        public const int ttAccVsTime = 9;
        public const int ttForceVelocity = 10;
        public const int ttVsPosition = 11;
        public const int ttStrainTime = 12;

        // Frequency Table Types
        public const int tyPeriod = 0;
        public const int tyFrequency = 1;

        // Beam Prop Table Entries
        public const int ptBeamStiffModVsTemp = 1001;
        public const int ptBeamAlphaVsTemp = 1002;
        public const int ptBeamConductVsTemp = 1003;
        public const int ptBeamCpVsTemp = 1004;
        public const int ptBeamStiffModVsTime = 1005;
        public const int ptBeamConductVsTime = 1006;
        public const int ptSpringAxialVsDisp = 1007;
        public const int ptSpringTorqueVsTwist = 1008;
        public const int ptSpringAxialVsVelocity = 1009;
        public const int ptTrussAxialStressVsStrain = 1010;
        public const int ptBeamAxialStressVsStrain = 1011;
        public const int ptBeamMomentK1 = 1012;
        public const int ptBeamMomentK2 = 1013;
        public const int ptConnectionShear1 = 1014;
        public const int ptConnectionShear2 = 1015;
        public const int ptConnectionAxial = 1016;
        public const int ptConnectionBend1 = 1017;
        public const int ptConnectionBend2 = 1018;
        public const int ptConnectionTorque = 1019;
        public const int ptBeamYieldVsTemp = 1020;

        // Plate Prop Table Entries
        public const int ptPlateModVsTemp = 2001;
        public const int ptPlateAlphaVsTemp = 2002;
        public const int ptPlateConductVsTemp = 2003;
        public const int ptPlateCpVsTemp = 2004;
        public const int ptPlateModVsTime = 2005;
        public const int ptPlateConductVsTime = 2006;
        public const int ptPlateStressVsStrain = 2007;
        public const int ptPlateYieldVsTemp = 2008;

        // Brick Prop Table Entries
        public const int ptBrickModVsTemp = 3001;
        public const int ptBrickAlphaVsTemp = 3002;
        public const int ptBrickConductVsTemp = 3003;
        public const int ptBrickCpVsTemp = 3004;
        public const int ptBrickModVsTime = 3005;
        public const int ptBrickConductVsTime = 3006;
        public const int ptBrickStressVsStrain = 3007;
        public const int ptBrickYieldVsTemp = 3008;

        // Creep Laws
        public const int clConcreteHyperbolic = 0;
        public const int clConcreteViscoChain = 1;
        public const int clConcreteUserDefined = 2;
        public const int clPrimaryPower = 3;
        public const int clSecondaryPower = 4;
        public const int clPrimarySecondaryPower = 5;
        public const int clSecondaryHyperbolic = 6;
        public const int clSecondaryExponential = 7;
        public const int clThetaProjection = 8;
        public const int clGenGraham = 9;
        public const int clGenBlackburn = 10;
        public const int clUserDefined = 11;

        // Load Case Types
        public const int kNoInertia = 0;
        public const int kGravity = 1;
        public const int kAccelerations = 2;

        // Freedom Case Types
        public const int kNormalFreedom = 0;
        public const int kFreeBodyInertiaRelief = 1;
        public const int kSingleSymmetryInertiaXY = 2;
        public const int kSingleSymmetryInertiaYZ = 3;
        public const int kSingleSymmetryInertiaZX = 4;
        public const int kDoubleSymmetryInertiaX = 5;
        public const int kDoubleSymmetryInertiaY = 6;
        public const int kDoubleSymmetryInertiaZ = 7;

        // Global Load and Freedom Cases
        public const int ipRefTemp = 0;
        public const int ipGlobOrigX = 1;
        public const int ipGlobOrigY = 2;
        public const int ipGlobOrigZ = 3;
        public const int ipGlobAccX = 4;
        public const int ipGlobAccY = 5;
        public const int ipGlobAccZ = 6;
        public const int ipGlobAngVelX = 7;
        public const int ipGlobAngVelY = 8;
        public const int ipGlobAngVelZ = 9;
        public const int ipGlobAngAccX = 10;
        public const int ipGlobAngAccY = 11;
        public const int ipGlobAngAccZ = 12;

        // Damping Types
        public const int dtNoDamping = 0;
        public const int dtRayleighDamping = 1;
        public const int dtModalDamping = 2;
        public const int dtViscousDamping = 3;

        // Rayleigh Modes
        public const int rmSetFrequencies = 0;
        public const int rmSetAlphaBeta = 1;

        // Entity Solver Result Types - HEAT
        public const int hrNodeFlux = 1;
        public const int hrBeamFlux = 2;
        public const int hrPlateFlux = 3;
        public const int hrBrickFlux = 4;

        // Entity Solver Result Types - FREQUENCY
        public const int frBeamForcePattern = 5;
        public const int frBeamStrainPattern = 6;
        public const int frPlateStressPattern = 7;
        public const int frPlateStrainPattern = 8;
        public const int frBrickStressPattern = 9;
        public const int frBrickStrainPattern = 10;

        // Entity Solver Result Types - STRUCTURAL
        public const int srNodeReaction = 11;
        public const int srNodeVelocity = 12;
        public const int srNodeAcceleration = 13;
        public const int srBeamForce = 14;
        public const int srBeamMNLStress = 15;
        public const int srBeamStrain = 16;
        public const int srPlateStress = 17;
        public const int srPlateStrain = 18;
        public const int srBrickStress = 19;
        public const int srBrickStrain = 20;
        public const int srElementNodeForce = 21;

        // Solver Defaults - LOGICALS
        public const int spDoSturm = 1;
        public const int spNonlinearMaterial = 2;
        public const int spNonlinearGeometry = 4;
        public const int spAddKg = 6;
        public const int spCalcDampingRatios = 8;
        public const int spIncludeLinkReactions = 9;
        public const int spFullSystemTransient = 10;
        public const int spNonlinearHeat = 11;
        public const int spLumpedLoadBeam = 12;
        public const int spLumpedLoadPlate = 13;
        public const int spLumpedLoadBrick = 14;
        public const int spLumpedMassBeam = 15;
        public const int spLumpedMassPlate = 16;
        public const int spLumpedMassBrick = 17;
        public const int spForceDrillCheck = 18;
        public const int spSaveRestartFile = 20;
        public const int spSaveIntermediate = 21;
        public const int spExcludeMassX = 22;
        public const int spExcludeMassY = 23;
        public const int spExcludeMassZ = 24;
        public const int spSaveSRSSSpectral = 25;
        public const int spSaveCQCSpectral = 26;
        public const int spDoResidualsCheck = 27;
        public const int spSuppressAllSingularities = 28;
        public const int spSaveModalResults = 29;
        public const int spSpectralReactionAsInertia = 30;
        public const int spReducedLogFile = 31;
        public const int spIncludeRotationalMass = 32;
        public const int spIgnoreCompressiveBeamKg = 33;
        public const int spAutoScaleKg = 34;
        public const int spScaleSupports = 36;
        public const int spAutoShift = 37;
        public const int spSaveTableInsertedSteps = 38;
        public const int spSaveLastRestartStep = 39;
        public const int spAutoAssignPathDivisions = 40;
        public const int spDoInstantNTA = 41;
        public const int spAllowExtraIterations = 42;
        public const int spPredictImpact = 43;

        // Solver Defaults - INTEGERS
        public const int spTreeStartNumber = 1;
        public const int spNumFrequency = 2;
        public const int spNumBucklingModes = 3;
        public const int spMaxIterationEig = 4;
        public const int spMaxIterationNonlin = 5;
        public const int spNumBeamSlicesSpectral = 6;
        public const int spMaxConjugateGradientIter = 7;
        public const int spMaxNumWarnings = 8;
        public const int spFiniteStrainDefinition = 9;
        public const int spBeamLength = 10;
        public const int spFormStiffMatrix = 11;
        public const int spMaxUpdateInterval = 12;
        public const int spFormNonlinHeatStiffMatrix = 13;
        public const int spExpandWorkingSet = 14;
        public const int spMinNumViscoUnits = 15;
        public const int spMaxNumViscoUnits = 16;
        public const int spCurveFitTimeUnit = 17;
        public const int spStaticAutoStepping = 18;
        public const int spBeamKgType = 19;
        public const int spDynamicAutoStepping = 20;

        // Solver Defaults - DOUBLES
        public const int spEigenTolerance = 1;
        public const int spFrequencyShift = 2;
        public const int spBucklingShift = 3;
        public const int spNonlinDispTolerance = 4;
        public const int spNonlinResidualTolerance = 5;
        public const int spTransientReferenceTemperature = 6;
        public const int spRelaxationFactor = 7;
        public const int spNonlinHeatTolerance = 8;
        public const int spMinimumTimeStep = 9;
        public const int spWilsonTheta = 10;
        public const int spNewmarkBeta = 11;
        public const int spGlobalZeroDiagonal = 12;
        public const int spConjugateGradientTol = 13;
        public const int spMinimumDimension = 14;
        public const int spMinimumInternalAngle = 15;
        public const int spZeroForce = 16;
        public const int spZeroDiagonal = 17;
        public const int spZeroContactFactor = 18;
        public const int spFrictionCutoffStrain = 19;
        public const int spZeroTranslation = 20;
        public const int spZeroRotation = 21;
        public const int spDrillStiffFactor = 22;
        public const int spMaxNormalsAngle = 24;
        public const int spMaximumRotation = 26;
        public const int spZeroDisplacement = 27;
        public const int spMaximumDispRatio = 28;
        public const int spMinimumLoadReductionFactor = 29;
        public const int spMaxDispChange = 30;
        public const int spMaxResidualChange = 31;
        public const int spZeroFrequency = 32;
        public const int spZeroBucklingEigen = 33;
        public const int spCurveFitTime = 34;
        public const int spSpacingBias = 35;
        public const int spTimeStepParam = 36;
        public const int spSlidingFrictionFactor = 37;
        public const int spMNLTangentRatio = 38;
        public const int spStickingFrictionFactor = 39;
        public const int spMinArcLengthFactor = 40;
        public const int spMaxFibreStrainInc = 41;

        // Modal Load Types
        public const int mtBaseAcc = 0;
        public const int mtBaseVel = 1;
        public const int mtBaseDisp = 2;
        public const int mtAppliedLoad = 3;

        // Solver Types
        public const int stSkyline = 0;
        public const int stSparse = 1;
        public const int stIterativePCG = 3;

        // Solver Temperature Types
        public const int tdNone = 0;
        public const int tdCombined = 1;

        // Harmonic Load Types
        public const int htVsFrequency = 0;
        public const int htVsTime = 1;

        // Sort Types
        public const int rnNone = 0;
        public const int rnTree = 1;
        public const int rnGeometry = 2;
        public const int rnAMD = 3;

        // Utility
        public const int ztAbsolute = 0;
        public const int ztRelative = 1;

        // Boolean Types
        public const int btFalse = 0;
        public const int btTrue = 1;

        // Error Codes
        public const int ERR7_InvalidRegionalSettings = -6;
        public const int ERR7_InvalidDLLsPresent = -5;
        public const int ERR7_APINotInitialised = -4;
        public const int ERR7_InvalidErrorCode = -3;
        public const int ERR7_APINotLicensed = -2;
        public const int ERR7_UnknownError = -1;
        public const int ERR7_NoError = 0;
        public const int ERR7_FileAlreadyOpen = 1;
        public const int ERR7_FileNotFound = 2;
        public const int ERR7_FileNotSt7 = 3;
        public const int ERR7_InvalidFileName = 4;
        public const int ERR7_FileIsNewer = 5;
        public const int ERR7_CannotReadFile = 6;
        public const int ERR7_InvalidScratchPath = 7;
        public const int ERR7_FileNotOpen = 8;
        public const int ERR7_ExceededTotal = 9;
        public const int ERR7_DataNotFound = 10;
        public const int ERR7_InvalidResultFile = 11;
        public const int ERR7_ResultFileNotOpen = 12;
        public const int ERR7_ExceededResultCase = 13;
        public const int ERR7_UnknownResultType = 14;
        public const int ERR7_UnknownResultLocation = 15;
        public const int ERR7_UnknownSurfaceLocation = 16;
        public const int ERR7_UnknownProperty = 17;
        public const int ERR7_InvalidEntity = 18;
        public const int ERR7_InvalidBeamPosition = 19;
        public const int ERR7_InvalidLoadCase = 20;
        public const int ERR7_InvalidFreedomCase = 21;
        public const int ERR7_UnknownTitle = 22;
        public const int ERR7_UnknownUCS = 23;
        public const int ERR7_TooManyBeamStations = 24;
        public const int ERR7_UnknownSubType = 25;
        public const int ERR7_GroupIdDoesNotExist = 26;
        public const int ERR7_InvalidFileUnit = 27;
        public const int ERR7_CannotSaveFile = 28;
        public const int ERR7_ResultFileIsOpen = 29;
        public const int ERR7_InvalidUnits = 30;
        public const int ERR7_InvalidEntityNodes = 31;
        public const int ERR7_InvalidUCSType = 32;
        public const int ERR7_InvalidUCSID = 33;
        public const int ERR7_UCSIDAlreadyExists = 34;
        public const int ERR7_CaseNameAlreadyExists = 35;
        public const int ERR7_InvalidEntityNumber = 36;
        public const int ERR7_InvalidBeamEnd = 37;
        public const int ERR7_InvalidBeamDir = 38;
        public const int ERR7_InvalidPlateEdge = 39;
        public const int ERR7_InvalidBrickFace = 40;
        public const int ERR7_InvalidBeamType = 41;
        public const int ERR7_InvalidPlateType = 42;
        public const int ERR7_InvalidMaterialType = 43;
        public const int ERR7_PropertyAlreadyExists = 44;
        public const int ERR7_InvalidBeamSectionType = 45;
        public const int ERR7_PropertyNotSpring = 46;
        public const int ERR7_PropertyNotCable = 47;
        public const int ERR7_PropertyNotTruss = 48;
        public const int ERR7_PropertyNotCutOffBar = 49;
        public const int ERR7_PropertyNotPointContact = 50;
        public const int ERR7_PropertyNotBeam = 51;
        public const int ERR7_PropertyNotPipe = 52;
        public const int ERR7_PropertyNotConnectionBeam = 53;
        public const int ERR7_InvalidSectionParameters = 54;
        public const int ERR7_PropertyNotUserDefinedBeam = 55;
        public const int ERR7_MaterialIsUserDefined = 56;
        public const int ERR7_MaterialNotIsotropic = 57;
        public const int ERR7_MaterialNotOrthotropic = 58;
        public const int ERR7_InvalidRubberModel = 59;
        public const int ERR7_MaterialNotRubber = 60;
        public const int ERR7_InvalidSectionProperties = 61;
        public const int ERR7_PlateDoesNotHaveThickness = 62;
        public const int ERR7_IncompatibleMaterialCombination = 63;
        public const int ERR7_UnknownSolver = 64;
        public const int ERR7_InvalidSolverMode = 65;
        public const int ERR7_InvalidMirrorOption = 66;
        public const int ERR7_SectionCannotBeMirrored = 67;
        public const int ERR7_InvalidTableType = 68;
        public const int ERR7_InvalidTableName = 69;
        public const int ERR7_TableNameAlreadyExists = 70;
        public const int ERR7_InvalidNumberOfEntries = 71;
        public const int ERR7_InvalidZipType = 72;
        public const int ERR7_TableDoesNotExist = 73;
        public const int ERR7_NotFrequencyTable = 74;
        public const int ERR7_InvalidFrequencyType = 75;
        public const int ERR7_InvalidTableSetting = 76;
        public const int ERR7_IncompatibleTableType = 77;
        public const int ERR7_IncompatibleCriterionCombination = 78;
        public const int ERR7_InvalidModalFile = 79;
        public const int ERR7_InvalidCombinationCaseNumber = 80;
        public const int ERR7_InvalidInitialCaseNumber = 81;
        public const int ERR7_InvalidInitialFile = 82;
        public const int ERR7_InvalidModeNumber = 83;
        public const int ERR7_BeamIsNotBXS = 84;
        public const int ERR7_InvalidDampingType = 85;
        public const int ERR7_InvalidRayleighMode = 86;
        public const int ERR7_CannotReadBXS = 87;
        public const int ERR7_InvalidResultType = 88;
        public const int ERR7_InvalidSolverParameter = 89;
        public const int ERR7_InvalidModalLoadType = 90;
        public const int ERR7_InvalidTimeRow = 91;
        public const int ERR7_SparseSolverNotLicenced = 92;
        public const int ERR7_InvalidSolverScheme = 93;
        public const int ERR7_InvalidSortOption = 94;
        public const int ERR7_IncompatibleResultFile = 95;
        public const int ERR7_InvalidLinkType = 96;
        public const int ERR7_InvalidLinkData = 97;
        public const int ERR7_OnlyOneLoadCase = 98;
        public const int ERR7_OnlyOneFreedomCase = 99;
        public const int ERR7_InvalidLoadID = 100;
        public const int ERR7_InvalidBeamLoadType = 101;
        public const int ERR7_InvalidStringID = 102;
        public const int ERR7_InvalidPatchType = 103;
        public const int ERR7_IncrementDoesNotExist = 104;
        public const int ERR7_InvalidLoadCaseType = 105;
        public const int ERR7_InvalidFreedomCaseType = 106;
        public const int ERR7_InvalidHarmonicLoadType = 107;
        public const int ERR7_InvalidTemperatureType = 108;
        public const int ERR7_InvalidPatchTypeForPlate = 109;
        public const int ERR7_InvalidAttributeType = 110;
        public const int ERR7_MaterialNotAnisotropic = 111;
        public const int ERR7_InvalidMatrixType = 112;
        public const int ERR7_MaterialNotUserDefined = 113;
        public const int ERR7_InvalidIndex = 114;
        public const int ERR7_InvalidContactType = 115;
        public const int ERR7_InvalidContactSubType = 116;
        public const int ERR7_InvalidCutoffType = 117;
        public const int ERR7_ResultQuantityNotAvailable = 118;
        public const int ERR7_YieldNotMCDP = 119;
        public const int ERR7_CombinationDoesNotExist = 120;
        public const int ERR7_InvalidSeismicCase = 121;
        public const int ERR7_InvalidImportExportMode = 122;
        public const int ERR7_CannotReadImportFile = 123;
        public const int ERR7_InvalidAnsysImportFormat = 124;
        public const int ERR7_InvalidAnsysArrayStatus = 125;
        public const int ERR7_CannotWriteExportFile = 126;
        public const int ERR7_InvalidAnsysExportFormat = 127;
        public const int ERR7_InvalidAnsysEndReleaseOption = 128;
        public const int ERR7_InvalidAnsysExportUnits = 129;
        public const int ERR7_InvalidSt7ExportFormat = 130;
        public const int ERR7_InvalidUVPos = 131;
        public const int ERR7_InvalidResponseType = 132;
        public const int ERR7_InvalidLayoutID = 133;
        public const int ERR7_InvalidPlateSurface = 134;
        public const int ERR7_MeshingErrors = 135;
        public const int ERR7_InvalidZipTolerance = 136;
        public const int ERR7_InvalidTaperAxis = 137;
        public const int ERR7_InvalidTaperType = 138;
        public const int ERR7_InvalidTaperRatio = 139;
        public const int ERR7_InvalidPositionType = 140;
        public const int ERR7_InvalidPreLoadType = 141;
        public const int ERR7_InvalidVertexType = 142;
        public const int ERR7_InvalidVertexMeshSize = 143;
        public const int ERR7_InvalidGeometryEdgeType = 144;
        public const int ERR7_InvalidPropertyNumber = 145;
        public const int ERR7_InvalidFaceSurface = 146;
        public const int ERR7_InvalidModType = 147;
        public const int ERR7_MaterialNotSoil = 148;
        public const int ERR7_MaterialNotFluid = 149;
        public const int ERR7_SoilTypeNotDC = 150;
        public const int ERR7_SoilTypeNotCC = 151;
        public const int ERR7_MaterialNotLaminate = 152;
        public const int ERR7_InvalidLaminateID = 153;
        public const int ERR7_LaminateNameAlreadyExists = 154;
        public const int ERR7_LaminateIDAlreadyExists = 155;
        public const int ERR7_PlyDoesNotExist = 156;
        public const int ERR7_ExceededMaxNumPlies = 157;
        public const int ERR7_LayoutIDAlreadyExists = 158;
        public const int ERR7_InvalidNumModes = 159;
        public const int ERR7_InvalidLTAMethod = 160;
        public const int ERR7_InvalidLTASolutionType = 161;
        public const int ERR7_ExceededMaxNumStages = 162;
        public const int ERR7_StageDoesNotExist = 163;
        public const int ERR7_ExceededMaxNumSpectralCases = 164;
        public const int ERR7_InvalidSpectralCase = 165;
        public const int ERR7_InvalidSpectrumType = 166;
        public const int ERR7_InvalidResultsSign = 167;
        public const int ERR7_InvalidPositionTableAxis = 168;
        public const int ERR7_InvalidInitialConditionsType = 169;
        public const int ERR7_ExceededMaxNumNodeHistory = 170;
        public const int ERR7_NodeHistoryDoesNotExist = 171;
        public const int ERR7_InvalidTransientTempType = 172;
        public const int ERR7_InvalidTimeUnit = 173;
        public const int ERR7_InvalidLoadPath = 174;
        public const int ERR7_InvalidTempDependenceType = 175;
        public const int ERR7_InvalidTrigType = 176;
        public const int ERR7_InvalidUserEquation = 177;
        public const int ERR7_InvalidCreepID = 178;
        public const int ERR7_CreepIDAlreadyExists = 179;
        public const int ERR7_InvalidCreepLaw = 180;
        public const int ERR7_InvalidCreepHardeningLaw = 181;
        public const int ERR7_InvalidCreepViscoChainRow = 182;
        public const int ERR7_InvalidCreepFunctionType = 183;
        public const int ERR7_InvalidCreepShrinkageType = 184;
        public const int ERR7_InvalidTableRow = 185;
        public const int ERR7_ExceededMaxNumRows = 186;
        public const int ERR7_InvalidLoadPathTemplateID = 187;
        public const int ERR7_LoadPathTemplateIDAlreadyExists = 188;
        public const int ERR7_InvalidLoadPathLane = 189;
        public const int ERR7_ExceededMaxNumLoadPathTemplates = 190;
        public const int ERR7_ExceededMaxNumLoadPathVehicles = 191;
        public const int ERR7_InvalidLoadPathVehicle = 192;
        public const int ERR7_InvalidMobilityType = 193;
        public const int ERR7_InvalidAxisSystem = 194;
        public const int ERR7_InvalidLoadPathID = 195;
        public const int ERR7_LoadPathIDAlreadyExists = 196;
        public const int ERR7_InvalidPathDefinition = 197;
        public const int ERR7_InvalidLoadPathShape = 198;
        public const int ERR7_InvalidLoadPathSurface = 199;
        public const int ERR7_InvalidNumPathDivs = 200;
        public const int ERR7_InvalidGeometryCavityLoop = 201;
        public const int ERR7_InvalidLimitEnvelope = 202;
        public const int ERR7_ExceededMaxNumLimitEnvelopes = 203;
        public const int ERR7_InvalidCombEnvelope = 204;
        public const int ERR7_ExceededMaxNumCombEnvelopes = 205;
        public const int ERR7_InvalidFactorsEnvelope = 206;
        public const int ERR7_ExceededMaxNumFactorsEnvelopes = 207;
        public const int ERR7_InvalidLimitEnvelopeType = 208;
        public const int ERR7_InvalidCombEnvelopeType = 209;
        public const int ERR7_InvalidFactorsEnvelopeType = 210;
        public const int ERR7_InvalidCombEnvelopeAccType = 211;
        public const int ERR7_InvalidEnvelopeSet = 212;
        public const int ERR7_ExceededMaxNumEnvelopeSets = 213;
        public const int ERR7_InvalidEnvelopeSetType = 214;
        public const int ERR7_InvalidCombResFile = 215;
        public const int ERR7_ExceededMaxNumCombResFiles = 216;
        public const int ERR7_CannotCombResFiles = 217;
        public const int ERR7_InvalidStartEndTimes = 218;
        public const int ERR7_InvalidNumSteps = 219;
        public const int ERR7_InvalidLibraryPath = 220;
        public const int ERR7_InvalidLibraryType = 221;
        public const int ERR7_InvalidLibraryID = 222;
        public const int ERR7_InvalidLibraryName = 223;
        public const int ERR7_InvalidLibraryItemID = 224;
        public const int ERR7_InvalidLibraryItemName = 225;
        public const int ERR7_InvalidDisplayOptionsPath = 226;
        public const int ERR7_InvalidSolverPath = 227;
        public const int ERR7_InvalidCementHardeningType = 228;
        public const int ERR7_ZeroPlateElements = 229;
        public const int ERR7_CannotMakeBXS = 230;
        public const int ERR7_CannotCalculateBXSData = 231;
        public const int ERR7_InvalidSurfaceMeshTargetType = 232;
        public const int ERR7_InvalidModalNodeReactType = 233;
        public const int ERR7_InvalidAxis = 234;
        public const int ERR7_InvalidBeamAxisType = 235;
        public const int ERR7_InvalidStaadCountryCodeOption = 236;
        public const int ERR7_InvalidGeometryFormatProtocol = 237;
        public const int ERR7_InvalidDXFBeamOption = 238;
        public const int ERR7_InvalidDXFPlateOption = 239;
        public const int ERR7_InvalidLoadPathLaneFactorType = 240;
        public const int ERR7_InvalidLoadPathVehicleInstance = 241;
        public const int ERR7_InvalidNumBeamStations = 242;
        public const int ERR7_ResFileUnsupportedType = 243;
        public const int ERR7_ResFileAlreadyOpen = 244;
        public const int ERR7_ResFileInvalidNumCases = 245;
        public const int ERR7_ResFileNotOpen = 246;
        public const int ERR7_ResFileInvalidCase = 247;
        public const int ERR7_ResFileDoesNotHaveEntity = 248;
        public const int ERR7_ResFileInvalidQuantity = 249;
        public const int ERR7_ResFileQuantityNotExist = 250;
        public const int ERR7_ResFileCantSave = 251;
        public const int ERR7_ResFileCantClearQuantity = 252;
        public const int ERR7_ResFileContainsNoElements = 253;
        public const int ERR7_ResFileContainsNoNodes = 254;
        public const int ERR7_ResFileInvalidName = 255;
        public const int ERR7_ResFileAssociationNotAllowed = 256;
        public const int ERR7_ResFileIncompatibleQuantity = 257;
        public const int ERR7_CannotEditSolverFiles = 258;
        public const int ERR7_CannotOpenResultFile = 259;
        public const int ERR7_CouldNotShowModelWindow = 260;
        public const int ERR7_ModelWindowWasNotShowing = 261;
        public const int ERR7_CantDoWithModalWindows = 262;
        public const int ERR7_InvalidSelectionEndEdgeFace = 263;
        public const int ERR7_CouldNotCreateModelWindow = 264;
        public const int ERR7_ModelWindowWasNotCreated = 265;
        public const int ERR7_InvalidImageType = 266;
        public const int ERR7_InvalidImageDimensions = 267;
        public const int ERR7_InsufficientRamToCreateImage = 268;
        public const int ERR7_CannotSaveImageFile = 269;
        public const int ERR7_InvalidWindowDimensions = 270;
        public const int ERR7_InvalidResultQuantity = 271;
        public const int ERR7_InvalidResultSubQuantity = 272;
        public const int ERR7_InvalidComponent = 273;
        public const int ERR7_ResultIsNotAvailable = 274;
        public const int ERR7_InvalidUCSIndex = 275;
        public const int ERR7_InvalidDiagramAxis = 276;
        public const int ERR7_InvalidVectorComponents = 277;
        public const int ERR7_TableTypeIsNotTimeBased = 278;
        public const int ERR7_InvalidTableID = 279;
        public const int ERR7_LinkNotMasterSlave = 280;
        public const int ERR7_LinkNotSectorSymmetry = 281;
        public const int ERR7_LinkNotCoupling = 282;
        public const int ERR7_LinkNotPinned = 283;
        public const int ERR7_LinkNotRigid = 284;
        public const int ERR7_LinkNotShrink = 285;
        public const int ERR7_LinkNotTwoPoint = 286;
        public const int ERR7_LinkNotAttachment = 287;
        public const int ERR7_LinkNotMultiPoint = 288;
        public const int ERR7_InvalidCoupleType = 289;
        public const int ERR7_InvalidRigidPlane = 290;
        public const int ERR7_InvalidMultiPointFactorsType = 291;
        public const int ERR7_InvalidMultiPointLink = 292;
        public const int ERR7_InvalidAttachmentType = 293;
        public const int ERR7_ExceededMaxNumColumns = 294;
        public const int ERR7_CouldNotDestroyModelWindow = 295;
        public const int ERR7_CannotSetWindowParent = 296;
        public const int ERR7_InvalidLoadCaseFilePath = 297;
        public const int ERR7_InvalidStaadLengthUnit = 298;
        public const int ERR7_InvalidStaadForceUnit = 299;
        public const int ERR7_InvalidDuplicateFaceType = 300;
        public const int ERR7_InvalidNodeCoordinateKeepType = 301;
        public const int ERR7_CommentDoesNotExist = 302;
        public const int ERR7_InvalidFilePath = 303;
        public const int ERR7_InvalidContactYieldType = 304;
        public const int ERR7_InvalidNumMeshingLoops = 305;
        public const int ERR7_InvalidMeshPositionOnUCS = 306;
        public const int ERR7_InvalidK0Expression = 307;
        public const int ERR7_InvalidK1Expression = 308;
        public const int ERR7_NoPatchLoadsCreated = 309;
        public const int ERR7_InvalidResOptsBeamEnvelope = 310;
        public const int ERR7_InvalidResOptsRotationUnit = 311;
        public const int ERR7_InvalidResOptsHRASetting = 312;
        public const int ERR7_InvalidResOptsStageDisplacement = 313;
        public const int ERR7_InvalidToolOptsZipOptions = 314;
        public const int ERR7_InvalidToolOptsSubdivideOptions = 315;
        public const int ERR7_InvalidToolOptsCopyOptions = 316;
        public const int ERR7_InvalidToleranceType = 317;
        public const int ERR7_InvalidAttachPartsParams = 318;
        public const int ERR7_InvalidDrawParameters = 319;
        public const int ERR7_FilesStillOpen = 320;
        public const int ERR7_SolverStillRunning = 321;
        public const int ERR7_InvalidPolygonToFaceParameters = 322;
        public const int ERR7_InvalidResOptsStrainUnit = 323;
        public const int ERR7_FunctionNotSupported = 324;
        public const int ERR7_SoilTypeNotMC = 325;
        public const int ERR7_SoilTypeNotDP = 326;
        public const int ERR7_TooManyAnimations = 327;
        public const int ERR7_InvalidAnimationFile = 328;
        public const int ERR7_InvalidAnimationMode = 329;
        public const int ERR7_InsufficientFrames = 330;
        public const int ERR7_AnimationDimensionsTooSmall = 331;
        public const int ERR7_AnimationDimensionsTooLarge = 332;
        public const int ERR7_ReducedAnimation = 333;
        public const int ERR7_InvalidAnimationType = 334;
        public const int ERR7_CannotFindStubFile = 335;
        public const int ERR7_CouldNotSaveAnimationFile = 336;
        public const int ERR7_AnimationHandleOutOfRange = 337;
        public const int ERR7_AnimationNotRunning = 338;
        public const int ERR7_SoilTypeNotLS = 339;
        public const int ERR7_NoPolygonWasConverted = 340;
        public const int ERR7_InvalidAlphaTempType = 341;
        public const int ERR7_InvalidGravityDirection = 342;
        public const int ERR7_InvalidAttachmentDirection = 343;
        public const int ERR7_InvalidHardeningType = 344;
        public const int ERR7_ResultCaseNotInertiaRelief = 345;
        public const int ERR7_InvalidNumLayers = 346;
        public const int ERR7_PlateDoesNotHaveLayers = 347;
        public const int ERR7_ToolOperationFailed = 348;

        // Solver Error Codes
        public const int SE_NoLoadCaseSelected = 1001;
        public const int SE_IncompatibleRestartFile = 1002;
        public const int SE_ElementUsesInvalidProperty = 1003;
        public const int SE_InvalidElement = 1004;
        public const int SE_NeedNonlinearHeatSolver = 1005;
        public const int SE_TableNotFound = 1006;
        public const int SE_InvalidRestartFile = 1007;
        public const int SE_InvalidInitialFile = 1008;
        public const int SE_InvalidSolverResultFile = 1009;
        public const int SE_InvalidLink = 1010;
        public const int SE_InvalidPlateCohesionValue = 1011;
        public const int SE_InvalidBrickCohesionValue = 1012;
        public const int SE_NonlinearSolverRequired = 1013;
        public const int SE_NoLoadTablesDefined = 1014;
        public const int SE_NoVelocityDataInInitialFile = 1015;
        public const int SE_NoModesIncluded = 1016;
        public const int SE_InvalidTimeStep = 1017;
        public const int SE_LoadIncrementsNotDefined = 1018;
        public const int SE_NoFreedomCaseInIncrements = 1019;
        public const int SE_InvalidInitialTemperatureFile = 1020;
        public const int SE_InvalidFrequencyRange = 1021;
        public const int SE_ModelMixesAxiNonAxi = 1022;
        public const int SE_CompositeModuleNotAvailable = 1023;
        public const int SE_CannotFindSolver = 1024;
        public const int SE_UnknownException = 1025;
        public const int SE_DuplicateLinks = 1026;
        public const int SE_CannotAppendToFile = 1027;
        public const int SE_CannotOverwriteFile = 1028;
        public const int SE_CannotWriteToResultFile = 1029;
        public const int SE_CannotWriteToLogFile = 1030;
        public const int SE_CannotReadRestartFile = 1031;
        public const int SE_InitialConditionsNotValid = 1032;
        public const int SE_InvalidRayleighFactors = 1033;
        public const int SE_ShearPanelMustBeQuad4 = 1035;
        public const int SE_SingularPlateMatrix = 1036;
        public const int SE_SingularBrickMatrix = 1037;
        public const int SE_NoBeamProperties = 1038;
        public const int SE_NoPlateProperties = 1039;
        public const int SE_NoBrickProperties = 1040;
        public const int SE_MoreLoadIncrementsNeeded = 1041;
        public const int SE_RubberRequiresGNL = 1042;
        public const int SE_NoFreedomCaseSelected = 1043;
        public const int SE_InvalidSpectralVectors = 1044;
        public const int SE_NoSpectralResultsSelected = 1045;
        public const int SE_SpectralFactorsNotDefined = 1046;
        public const int SE_SpectralFactorsAllZero = 1047;
        public const int SE_NoTimeStepsSaved = 1048;
        public const int SE_InvalidDirectionVector = 1049;
        public const int SE_HarmonicFactorsAllZero = 1050;
        public const int SE_TemperatureDependenceCaseNotSet = 1051;
        public const int SE_ZeroLengthRigidLinkGenerated = 1052;
        public const int SE_InvalidStringGroupDefinition = 1053;
        public const int SE_InvalidPreTensionOnString = 1054;
        public const int SE_StringOrderHasChanged = 1055;
        public const int SE_BadTaperData = 1056;
        public const int SE_TaperedPlasticBeams = 1057;
        public const int SE_NoMovingLoadPathsInCases = 1058;
        public const int SE_NoResponseVariablesDefined = 1059;
        public const int SE_InvalidPlateVariableRequested = 1060;
        public const int SE_InvalidGravityCase = 1061;
        public const int SE_InvalidUserPlateCreepDefinition = 1062;
        public const int SE_InvalidUserBrickCreepDefinition = 1063;
        public const int SE_InvalidPlateShrinkageDefinition = 1064;
        public const int SE_InvalidBrickShrinkageDefinition = 1065;
        public const int SE_InvalidLaminateID = 1066;
        public const int SE_CannotReadWriteScratchPath = 1067;
        public const int SE_CannotConvertAttachmentLink = 1068;
        public const int SE_SoilRequiresMNL = 1069;
        public const int SE_ActiveStageHasNoIncrements = 1070;
        public const int SE_ConcreteCreepMNL = 1071;
        public const int SE_CannotConvertInterpMultiPoint = 1072;
        public const int SE_MissingInsituStress = 1073;
        public const int SE_InvalidMaterialNonlinearString = 1074;
        public const int SE_TensileInsituPlateStress = 1075;
        public const int SE_TensileInsituBrickStress = 1076;
        public const int SE_IncompatibleRestartUnits = 1077;
        public const int SE_CreepTimeTooShort = 1078;
        public const int SE_InvalidElements = 1079;
        public const int SE_InsufficientRestartFileSteps = 1080;
        public const int SE_NeedNodeTempNTASolver = 1081;
        public const int SE_SingleShotRestartFile = 1082;
        public const int SE_SkylineUsesBadSort = 1083;
        public const int SE_StagedSolutionFileNotFound = 1084;
        public const int SE_NeedTemperatureTables = 1085;
        public const int SE_AttachmentsInWrongGroup = 1086;
        public const int SE_StagingHasChanged = 1087;
        public const int SE_NoNodes = 1088;
        public const int SE_CQCRequiresDamping = 1089;

        // Other Constants
        public const int kMaxPlateResult = 1024;
        public const int kMaxBrickResult = 1024;
        public const int kMaxBeamRelease = 12;
        public const int kMaxDisp = 6;
        public const int kAllStations = 20;

        // UCS
        public const int kMaxUCSDoubles = 10;

        // Solvers
        public const int stLinearStaticSolver = 1;
        public const int stLinearBucklingSolver = 2;
        public const int stNonlinearStaticSolver = 3;
        public const int stNaturalFrequencySolver = 4;
        public const int stHarmonicResponseSolver = 5;
        public const int stSpectralResponseSolver = 6;
        public const int stLinearTransientDynamicSolver = 7;
        public const int stNonlinearTransientDynamicSolver = 8;
        public const int stSteadyHeatSolver = 9;
        public const int stTransientHeatSolver = 10;
        public const int stLoadInfluenceSolver = 11;
        public const int stQuasiStaticSolver = 12;

        // Solver Modes
        public const int smNormalRun = 1;
        public const int smProgressRun = 2;
        public const int smBackgroundRun = 3;
        public const int smNormalCloseRun = 4;

        // Primary Load Case
        public const int ipLoadCaseDefRefTemp = 0;
        public const int ipLoadCaseDefOriginX = 1;
        public const int ipLoadCaseDefOriginY = 2;
        public const int ipLoadCaseDefOriginZ = 3;
        public const int ipLoadCaseDefLinAccX = 4;
        public const int ipLoadCaseDefLinAccY = 5;
        public const int ipLoadCaseDefLinAccZ = 6;
        public const int ipLoadCaseDefAngVelX = 7;
        public const int ipLoadCaseDefAngVelY = 8;
        public const int ipLoadCaseDefAngVelZ = 9;
        public const int ipLoadCaseDefAngAccX = 10;
        public const int ipLoadCaseDefAngAccY = 11;
        public const int ipLoadCaseDefAngAccZ = 12;

        // Seismic Load Case
        public const int ipSeismicCaseDefAlpha = 0;
        public const int ipSeismicCaseDefPhi = 1;
        public const int ipSeismicCaseDefBeta = 2;
        public const int ipSeismicCaseDefK = 3;
        public const int ipSeismicCaseDefh0 = 4;
        public const int ipSeismicCaseDefDir = 5;
        public const int ipSeismicCaseDefLinAcc = 6;
        public const int ipSeismicCaseDefV1 = 7;
        public const int ipSeismicCaseDefV2 = 8;

        // Import/Export Modes
        public const int ieQuietRun = 0;
        public const int ieProgressRun = 1;

        // NASTRAN
        public const int ipNASTRANImportUnits = 0;
        public const int ipNASTRANFreedomCase = 0;
        public const int ipNASTRANLoadCase = 1;
        public const int ipNASTRANSolver = 2;
        public const int ipNASTRANExportUnits = 3;
        public const int ipNASTRANBeamStressSections = 4;
        public const int ipNASTRANBeamSectionGeometry = 5;
        public const int ipNASTRANExportHeatTransfer = 6;
        public const int ipNASTRANExportNSMass = 7;
        public const int ipNASTRANExportUnusedProps = 8;
        public const int ipNASTRANTemperatureCase = 9;
        public const int ipNASTRANExportZeroFields = 0;
        public const int ieNASTRANSolverLSA = 0;
        public const int ieNASTRANSolverNFA = 1;
        public const int ieNASTRANSolverLBA = 2;
        public const int ieNASTRANExportGeometryProps = 0;
        public const int ieNASTRANExportPropsOnly = 1;
        public const int naUnits_kg_N_m = 0;
        public const int naUnits_T_N_mm = 1;
        public const int naUnits_sl_lbf_ft = 2;
        public const int naUnits_lbm_lbf_in = 3;
        public const int naUnits_sl_lbf_in = 4;
        public const int naUnits_NoUnits = 5;

        // ANSYS
        public const int ipANSYSImportFormat = 0;
        public const int ipANSYSArrayParameters = 1;
        public const int ipANSYSImportLoadCaseFiles = 2;
        public const int ipANSYSImportIGESEntities = 3;
        public const int ipANSYSFixElementConnectivity = 4;
        public const int ipANSYSRemoveDuplicateProps = 5;
        public const int ipANSYSExportFormat = 0;
        public const int ipANSYSFreedomCase = 1;
        public const int ipANSYSLoadCase = 2;
        public const int ipANSYSUnits = 3;
        public const int ipANSYSEndRelease = 4;
        public const int ipANSYSExportNonlinearMat = 5;
        public const int ipANSYSExportHeatTransfer = 6;
        public const int ipANSYSExportPreLoadNSMass = 7;
        public const int ipANSYSExportTetraOption = 8;
        public const int ieANSYSBatchImport = 0;
        public const int ieANSYSCDBImport = 1;
        public const int ieANSYSBatchCDBImport = 2;
        public const int ieANSYSBatch1Export = 0;
        public const int ieANSYSBatch3Export = 1;
        public const int ieANSYSBlockedCDBExport = 2;
        public const int ieANSYSUnblockedCDBExport = 3;
        public const int ieANSYSArrayOverwrite = 0;
        public const int ieANSYSArrayIgnore = 1;
        public const int ieANSYSArrayPrompt = 2;
        public const int ieANSYSEndReleaseFixed = 0;
        public const int ieANSYSEndReleaseFull = 1;
        public const int anUnits_NoUnits = 0;
        public const int anUnits_kg_m_C = 1;
        public const int anUnits_g_cm_C = 2;
        public const int anUnits_T_mm_C = 3;
        public const int anUnits_sl_ft_F = 4;
        public const int anUnits_lbm_in_F = 5;

        // STAAD
        public const int ipSTAADCountryType = 0;
        public const int ipSTAADIncludeSectionLibrary = 1;
        public const int ipSTAADStripUnderscore = 2;
        public const int ipSTAADStripSectionSpaces = 3;
        public const int ipSTAADLengthUnit = 4;
        public const int ipSTAADForceUnit = 5;
        public const int ieSTAADAmericanCode = 0;
        public const int ieSTAADAustralianCode = 1;
        public const int ieSTAADBritishCode = 2;
        public const int sdLengthUnit_in = 0;
        public const int sdLengthUnit_ft = 1;
        public const int sdLengthUnit_cm = 2;
        public const int sdLengthUnit_m = 3;
        public const int sdLengthUnit_mm = 4;
        public const int sdLengthUnit_dm = 5;
        public const int sdLengthUnit_km = 6;
        public const int sdForceUnit_kip = 0;
        public const int sdForceUnit_lbf = 1;
        public const int sdForceUnit_kgf = 2;
        public const int sdForceUnit_MTf = 3;
        public const int sdForceUnit_N = 4;
        public const int sdForceUnit_kN = 5;
        public const int sdForceUnit_MN = 6;
        public const int sdForceUnit_dN = 7;

        // SAP2000
        public const int ipSAP2000ConvertBlackTo = 0;
        public const int ipSAP2000DecimalSeparator = 1;
        public const int ipSAP2000ThousandSeparator = 2;
        public const int ipSAP2000MergeDuplicateFreedomSets = 3;
        public const int ieSAP2000Period = 0;
        public const int ieSAP2000Comma = 1;
        public const int ieSAP2000Space = 2;
        public const int ieSAP2000None = 3;

        // ST7
        public const int ieSt7ExportCurrent = 0;
        public const int ieSt7Export106 = 1;
        public const int ieSt7Export21x = 2;
        public const int ieSt7Export22x = 3;
        public const int ieSt7Export23x = 4;

        // GEOMETRY
        public const int ipImportGeomProp = 0;
        public const int ipImportGeomCurvesToBeams = 1;
        public const int ipImportGeomGroupsAs = 2;
        public const int ipImportGeomColourAsProperty = 3;
        public const int ipImportGeomBlackReplacement = 4;
        public const int ipImportGeomACISBodiesAsGroups = 5;
        public const int ipImportGeomLengthUnit = 6;
        public const int ipExportGeomColour = 0;
        public const int ipExportGeomGroupsAsLevels = 1;
        public const int ipExportGeomFullGroupPath = 2;
        public const int ipExportGeomFormatProtocol = 3;
        public const int ipExportGeomCurve = 4;
        public const int ipExportGeomPeriodicFace = 5;
        public const int ipExportGeomKeepAnalytic = 6;
        public const int ipImportGeomTol = 0;
        public const int luGeomNONE = -1;
        public const int luGeomINCH = 0;
        public const int luGeomMILLIMETRE = 1;
        public const int luGeomFEET = 2;
        public const int luGeomMILES = 3;
        public const int luGeomMETRE = 4;
        public const int luGeomKILOMETRE = 5;
        public const int luGeomMIL = 6;
        public const int luGeomMICRON = 7;
        public const int luGeomCENTIMETRE = 8;
        public const int luGeomMICROINCH = 9;
        public const int luGeomUNSPECIFIED = 10;

        // Geometry Groups
        public const int ggNone = 0;
        public const int ggAuto = 1;
        public const int ggSubfigures = 2;
        public const int ggLevels = 3;
        public const int ggAssemblies = 1;

        // IGES Formats
        public const int ifBoundedSurface = 0;
        public const int ifTrimmedParametricSurface = 1;
        public const int ifOpenShell = 2;
        public const int ifManifoldSolidBRep = 3;

        // STEP Protocols
        public const int spConfigControlDesign = 0;
        public const int spAutomotiveDesign = 1;

        // GEOMETRY Export Format Options
        public const int ieModelOnly = 0;
        public const int ieParameterOnly = 1;
        public const int ieModelPreferred = 2;
        public const int ieParameterPreferred = 3;
        public const int ieSeamOnlyAsRequired = 0;
        public const int ieSplitOnFaceBoundary = 1;
        public const int ieSplitIntoHalves = 2;
        public const int ieColourNone = 0;
        public const int ieFaceColour = 1;
        public const int ieGroupColour = 2;
        public const int iePropertyColour = 3;

        // DXF Options
        public const int ipDXFImportFrozenLayers = 0;
        public const int ipDXFImportLayersAsGroups = 1;
        public const int ipDXFImportColoursAsProps = 2;
        public const int ipDXFImportPolylineAsPlates = 3;
        public const int ipDXFImportPolygonAsBricks = 4;
        public const int ipDXFImportSegmentsPerCircle = 5;
        public const int ipDXFExportPlatesBricks3DFaces = 0;
        public const int ipDXFExportGroupsAsLayers = 1;
        public const int ipDXFExportPropColoursAsEntityColours = 2;
        public const int ipDXFExportBeamsAs = 3;
        public const int ipDXFExportPlatesAs = 4;
        public const int bmLine = 0;
        public const int bmSection = 1;
        public const int bmSolid = 2;
        public const int plSurface = 0;
        public const int plSolid = 1;

        // Geometry Groups Settings
        public const int grNone = 0;
        public const int grAuto = 1;
        public const int grSubfigures = 2;
        public const int grLevels = 3;
        public const int grAssembly = 1;

        // BXS
        public const int ipBXSXBar = 0;
        public const int ipBXSYBar = 1;
        public const int ipBXSArea = 2;
        public const int ipBXSI11 = 3;
        public const int ipBXSI22 = 4;
        public const int ipBXSAngle = 5;
        public const int ipBXSZ11Plus = 6;
        public const int ipBXSZ11Minus = 7;
        public const int ipBXSZ22Plus = 8;
        public const int ipBXSZ22Minus = 9;
        public const int ipBXSS11 = 10;
        public const int ipBXSS22 = 11;
        public const int ipBXSr1 = 12;
        public const int ipBXSr2 = 13;
        public const int ipBXSSA1 = 14;
        public const int ipBXSSA2 = 15;
        public const int ipBXSSL1 = 16;
        public const int ipBXSSL2 = 17;
        public const int ipBXSIXX = 18;
        public const int ipBXSIYY = 19;
        public const int ipBXSIXY = 20;
        public const int ipBXSIxxL = 21;
        public const int ipBXSIyyL = 22;
        public const int ipBXSIxyL = 23;
        public const int ipBXSZxxPlus = 24;
        public const int ipBXSZxxMinus = 25;
        public const int ipBXSZyyPlus = 26;
        public const int ipBXSZyyMinus = 27;
        public const int ipBXSSxx = 28;
        public const int ipBXSSyy = 29;
        public const int ipBXSrx = 30;
        public const int ipBXSry = 31;
        public const int ipBXSJ = 32;
        public const int ipBXSIw = 33;

        // GEOMETRY CLEAN - DOUBLES
        public const int ipGeometryAccuracy = 0;
        public const int ipGeometryFeatureLength = 1;
        public const int ipGeometryEdgeMergeAngle = 2;

        // GEOMETRY CLEAN - INTEGERS
        public const int ipGeometryAccuracyType = 0;
        public const int ipGeometryFeatureType = 1;
        public const int ipGeometryActOnWholeModel = 2;
        public const int ipGeometryFreeEdgesOnly = 3;
        public const int ipGeometryDuplicateFaces = 4;
        public const int dfGeometryLeave = 0;
        public const int dfGeometryDeleteOne = 1;
        public const int dfGeometryDeleteBoth = 2;

        // MESH CLEAN - DOUBLES
        public const int ipMeshTolerance = 0;

        // MESH CLEAN - INTEGERS
        public const int ipMeshToleranceType = 0;
        public const int ipZipNodes = 1;
        public const int ipRemoveDuplicateElements = 2;
        public const int ipFixElementConnectivity = 3;
        public const int ipDeleteFreeNodes = 4;
        public const int ipDoBeams = 5;
        public const int ipDoPlates = 6;
        public const int ipDoBricks = 7;
        public const int ipDoLinks = 8;
        public const int ipZeroLengthLinks = 9;
        public const int ipZeroLengthBeams = 10;
        public const int ipNodeAttributeKeep = 11;
        public const int ipNodeCoordinates = 12;
        public const int ipAllowDifferentProps = 13;
        public const int ipActOnWholeModel = 14;
        public const int dfLeaveAll = 0;
        public const int dfLeaveOne = 1;
        public const int dfLeaveNone = 2;

        // Attribute keep
        public const int naLower = 0;
        public const int naHigher = 1;
        public const int naAccumulate = 2;

        // Node coordinates
        public const int ncAverage = 0;
        public const int ncLowerNode = 1;
        public const int ncHigherNode = 2;
        public const int ncSelectedNode = 3;

        // SURFACE MESHING - INTEGERS
        public const int ipSurfaceMeshMode = 0;
        public const int ipSurfaceMeshSizeMode = 1;
        public const int ipSurfaceMeshTargetNodes = 2;
        public const int ipSurfaceMeshTargetPropertyID = 3;
        public const int ipSurfaceMeshAutoCreateProperties = 4;
        public const int ipSurfaceMeshMinEdgesPerCircle = 5;
        public const int ipSurfaceMeshApplyTransitioning = 6;
        public const int ipSurfaceMeshAllowUserStop = 7;
        public const int ipSurfaceMeshConsiderNearVertex = 8;
        public const int mmAuto = 0;
        public const int mmCustom = 1;
        public const int smPercentage = 0;
        public const int smAbsolute = 1;

        // SURFACE MESHING - DOUBLES
        public const int ipSurfaceMeshSize = 0;
        public const int ipSurfaceMeshLengthRatio = 1;
        public const int ipSurfaceMeshMaximumIncrease = 2;
        public const int ipSurfaceMeshOnEdgesLongerThan = 3;

        // TETRA MESHING
        public const int ipTetraMeshSize = 0;
        public const int ipTetraMeshProperty = 1;
        public const int ipTetraMeshInc = 2;
        public const int ipTetraMesh10 = 3;
        public const int ipTetraMeshGroupsAsSolids = 4;
        public const int ipTetraMeshSmooth = 5;
        public const int ipTetraMeshAutoCreateProperties = 7;
        public const int ipTetraMeshDeletePlates = 8;
        public const int ipTetraMeshMultiBodyOption = 9;
        public const int ipTetraMeshAllowUserStop = 10;
        public const int ipTetraMeshCheckSelfIntersect = 11;
        public const int msFine = 1;
        public const int msMedium = 2;
        public const int msCoarse = 3;
        public const int mbCancelMeshing = 0;
        public const int mbCavity = 1;
        public const int mbSeparateSolids = 2;

        // Polygon Meshing
        public const int ipMeshTargetNodes = 0;
        public const int ipMeshTargetPropertyID = 1;
        public const int ipMeshUCSID = 2;
        public const int ipMeshGroupID = 3;
        public const int ipMeshPositionUCS = 0;

        // IMAGE TYPES
        public const int itBitmap8Bit = 1;
        public const int itBitmap16Bit = 2;
        public const int itBitmap24Bit = 3;
        public const int itJPEG = 4;

        // WINDOW POPUP MENU GROUPS
        public const int imView = 1;
        public const int imDisplay = 2;
        public const int imShow = 3;
        public const int imSelect = 4;
        public const int imResults = 5;

        // WINDOW STATE
        public const int wsModelWindowNotCreated = 0;
        public const int wsModelWindowVisible = 1;
        public const int wsModelWindowMaximised = 2;
        public const int wsModelWindowMinimised = 3;
        public const int wsModelWindowHidden = 4;

        // Entity Display Settings - Node
        public const int ipNodeSelectedColour = 0;
        public const int ipNodeUnselectedColour = 1;
        public const int ipNodeShowFree = 2;
        public const int ipNodeNumberMode = 3;
        public const int ipNodeSymbol = 4;

        // Entity Display Settings - Beam
        public const int ipBeamDisplay = 0;
        public const int ipBeamShowRefNode = 1;
        public const int ipBeamShowOffset = 2;
        public const int ipBeamMoveToOffset = 3;
        public const int ipBeamLightShade = 4;
        public const int ipBeamGlobalColour = 5;
        public const int ipBeamOutlineColour = 6;
        public const int ipBeamEnd1Colour = 7;
        public const int ipBeamEnd2Colour = 8;
        public const int ipBeamRefNodeColour = 9;
        public const int ipBeamFilledMode = 10;
        public const int ipBeamContour = 11;
        public const int ipBeamShrink = 12;
        public const int ipBeamRoundFacets = 13;
        public const int ipBeamSpringCoils = 14;
        public const int ipBeamSpringAspect = 15;
        public const int ipBeamThickness = 16;
        public const int ipBeamSections = 17;
        public const int ipBeamOutlines = 18;
        public const int ipBeamShowAxes = 19;
        public const int ipBeamNumberMode = 20;

        // Entity Display Settings - Plate
        public const int ipPlateDisplay = 0;
        public const int ipPlateLightShade = 1;
        public const int ipPlateGlobalColour = 2;
        public const int ipPlateOutlineColour = 3;
        public const int ipPlateZPlusColour = 4;
        public const int ipPlateZMinusColour = 5;
        public const int ipPlateOffsetColour = 6;
        public const int ipPlateFilledMode = 7;
        public const int ipPlateContour = 8;
        public const int ipPlateShrink = 9;
        public const int ipPlateOutlines = 10;
        public const int ipPlateOutlineThickness = 11;
        public const int ipPlateShowAxes = 12;
        public const int ipPlateAxisOnPly = 13;
        public const int ipPlateOffset = 14;
        public const int ipPlateMoveToOffset = 15;
        public const int ipPlateNumberMode = 16;

        // Entity Display Settings - Brick
        public const int ipBrickLightShade = 0;
        public const int ipBrickGlobalColour = 1;
        public const int ipBrickOutlineColour = 2;
        public const int ipBrickFilledMode = 3;
        public const int ipBrickContour = 4;
        public const int ipBrickShrink = 5;
        public const int ipBrickOutlines = 6;
        public const int ipBrickOutlineThickness = 7;
        public const int ipBrickShowFreeFaces = 8;
        public const int ipBrickAxes1 = 9;
        public const int ipBrickAxes2 = 10;
        public const int ipBrickAxes3 = 11;
        public const int ipBrickNumberMode = 12;
        public const int ipBrickShowAllFaces = 13;

        // Entity Display Settings - Link
        public const int ipLinkGlobalColour = 0;
        public const int ipLinkMasterSlaveColour = 1;
        public const int ipLinkSectorSymmColour = 2;
        public const int ipLinkCouplingColour = 3;
        public const int ipLinkPinnedColour = 4;
        public const int ipLinkRigidColour = 5;
        public const int ipLinkShrinkColour = 6;
        public const int ipLinkTwoPointColour = 7;
        public const int ipLinkAttachmentColour = 8;
        public const int ipLinkMultiPointColour = 9;
        public const int ipLinkFilledMode = 10;
        public const int ipLinkNumberMode = 11;

        // Entity Display Settings - Load Path
        public const int ipLoadPathColour = 0;
        public const int ipLoadPathColourMode = 1;
        public const int ipLoadPathNumberMode = 2;
        public const int ipLoadPathShowDivisions = 3;
        public const int ipLoadPathThickness = 4;

        // Entity Display Settings - Vertex
        public const int ipVertexFreeColour = 0;
        public const int ipVertexFixedColour = 1;
        public const int ipVertexSelectedColour = 2;
        public const int ipVertextNumberMode = 3;
        public const int ipVertexSymbol = 4;

        // Entity Display Settings - Geometry Edge
        public const int ipEdgeShow = 0;
        public const int ipEdgeShowNonInterp = 1;
        public const int ipEdgeStyle = 2;
        public const int ipEdgeColourMode = 3;
        public const int ipEdgeColour = 4;
        public const int ipEdgeNonInterpColour = 5;

        // Entity Display Settings - Geometry Face
        public const int ipFaceWireframeColour = 0;
        public const int ipFaceShowWireframes = 1;
        public const int ipFaceShowControlPoints = 2;
        public const int ipFaceShowNormals = 3;
        public const int ipFaceWireframeStyle = 4;
        public const int ipFaceWireframeColourMode = 5;
        public const int ipFaceWireframeDensity = 6;

        // Entity Display Settings - Number Modes
        public const int nmNone = 0;
        public const int nmByElement = 1;
        public const int nmByProperty = 2;
        public const int nmByPropertyName = 3;
        public const int nmByID = 4;

        // Entity Display Settings - Display Modes
        public const int dmLine = 0;
        public const int dmSection = 1;
        public const int dmSolid = 2;
        public const int dmSlice = 3;

        // Entity Display Settings - Outline Modes
        public const int omOutlineOn = 0;
        public const int omOutlineOff = 1;
        public const int omOutlineFacet = 2;

        // Entity Display Settings - Filled Modes
        public const int fmPropertyColour = 1;
        public const int fmGroupColour = 2;
        public const int fmGlobalColour = 3;
        public const int fmPropertyWireframe = 4;
        public const int fmGroupWireframe = 5;
        public const int fmOutlineWireframe = 6;
        public const int fmOrientation = 7;

        // Entity Display Settings - Colour Modes
        public const int cmPropertyColour = 0;
        public const int cmGroupColour = 1;
        public const int cmFaceColour = 2;
        public const int cmFixedColour = 3;

        // Entity Display Settings - Load Path Colour Modes
        public const int cmLoadPathTemplateColour = 0;
        public const int cmLoadPathGroupColour = 1;
        public const int cmLoadPathColour = 2;
        public const int cmLoadPathGlobalColour = 3;

        // Entity Display Settings - Edge Styles
        public const int esThinEdge = 0;
        public const int esThickEdge = 1;

        // Entity Display Settings - Wireframe Styles
        public const int wsDepthShaded = 0;
        public const int wsConstantColour = 1;

        // Entity Display Settings - Node/Vertex Symbols
        public const int syDot1 = 0;
        public const int syDot2 = 1;
        public const int syDot3 = 2;
        public const int syDot4 = 3;
        public const int sySquare1 = 4;
        public const int sySquare2 = 5;
        public const int syDisk1 = 6;
        public const int syDisk2 = 7;
        public const int syCircle1 = 8;
        public const int syCircle2 = 9;
        public const int syCircle3 = 10;
        public const int sy3D1 = 11;
        public const int sy3D2 = 12;
        public const int sy3D3 = 13;

        // Entity Display Settings - Beam Contour Types
        public const int ctBeamNone = 0;
        public const int ctBeamLength = 1;
        public const int ctBeamAxis1 = 2;
        public const int ctBeamAxis2 = 3;
        public const int ctBeamAxis3 = 4;
        public const int ctBeamEA = 5;
        public const int ctBeamEI11 = 6;
        public const int ctBeamEI22 = 7;
        public const int ctBeamGJ = 8;
        public const int ctBeamEAFactor = 9;
        public const int ctBeamEI11Factor = 10;
        public const int ctBeamEI22Factor = 11;
        public const int ctBeamGJFactor = 12;
        public const int ctBeamOffset1 = 13;
        public const int ctBeamOffset2 = 14;
        public const int ctBeamStiffnessFactor1 = 15;
        public const int ctBeamStiffnessFactor2 = 16;
        public const int ctBeamStiffnessFactor3 = 17;
        public const int ctBeamStiffnessFactor4 = 18;
        public const int ctBeamStiffnessFactor5 = 19;
        public const int ctBeamStiffnessFactor6 = 20;
        public const int ctBeamMassFactor = 21;
        public const int ctBeamSupport1 = 22;
        public const int ctBeamSupport2 = 23;
        public const int ctBeamTemperature = 24;
        public const int ctBeamPreTension = 25;
        public const int ctBeamPreStrain = 26;
        public const int ctBeamTempGradient1 = 27;
        public const int ctBeamTempGradient2 = 28;
        public const int ctBeamPipePressureIn = 29;
        public const int ctBeamPipePressureOut = 30;
        public const int ctBeamPipeTempIn = 31;
        public const int ctBeamPipeTempOut = 32;
        public const int ctBeamConvectionCoeff = 33;
        public const int ctBeamConvectionAmbient = 34;
        public const int ctBeamRadiationCoeff = 35;
        public const int ctBeamRadiationAmbient = 36;
        public const int ctBeamHeatFlux = 37;
        public const int ctBeamHeatSource = 38;
        public const int ctBeamAgeAtFirstLoading = 39;

        // Entity Display Settings - Plate Contour Types
        public const int ctPlateNone = 0;
        public const int ctPlateAspectRatioMin = 1;
        public const int ctPlateAspectRatioMax = 2;
        public const int ctPlateWarping = 3;
        public const int ctPlateInternalAngle = 4;
        public const int ctPlateInternalAngleRatio = 5;
        public const int ctPlateDiscreteThicknessM = 6;
        public const int ctPlateContinuousThicknessM = 7;
        public const int ctPlateDiscreteThicknessB = 8;
        public const int ctPlateContinuousThicknessB = 9;
        public const int ctPlateOffset = 10;
        public const int ctPlateArea = 11;
        public const int ctPlateAxis1 = 12;
        public const int ctPlateAxis2 = 13;
        public const int ctPlateAxis3 = 14;
        public const int ctPlateTemperature = 15;
        public const int ctPlateEdgeSupport = 16;
        public const int ctPlateFaceSupport = 17;
        public const int ctPlatePreStressX = 18;
        public const int ctPlatePreStressY = 19;
        public const int ctPlatePresStressZ = 20;
        public const int ctPlatePreStressMagnitude = 21;
        public const int ctPlatePreStrainX = 22;
        public const int ctPlatePreStrainY = 23;
        public const int ctPlatePreStrainZ = 24;
        public const int ctPlatePreStrainMagnitude = 25;
        public const int ctPlateTempGradient = 26;
        public const int ctPlateEdgePressure = 27;
        public const int ctPlateEdgeShear = 28;
        public const int ctPlateEdgeNormalShear = 29;
        public const int ctPlatePressureNormal = 30;
        public const int ctPlatePressureGlobal = 31;
        public const int ctPlatePressureGlobalX = 32;
        public const int ctPlatePressureGlobalY = 33;
        public const int ctPlatePressureGlobalZ = 34;
        public const int ctPlateFaceShearX = 35;
        public const int ctPlateFaceShearY = 36;
        public const int ctPlateFaceShearMagnitude = 37;
        public const int ctPlateNSMass = 38;
        public const int ctPlateDynamicFactor = 39;
        public const int ctPlateConvectionCoeff = 40;
        public const int ctPlateConvectionAmbient = 41;
        public const int ctPlateRadiationCoeff = 42;
        public const int ctPlateRadiationAmbient = 43;
        public const int ctPlateHeatFlux = 44;
        public const int ctPlateConvectionCoeffZPlus = 45;
        public const int ctPlateConvectionCoeffZMinus = 46;
        public const int ctPlateConvectionAmbientZPlus = 47;
        public const int ctPlateConvectionAmbientZMinus = 48;
        public const int ctPlateRadiationCoeffZPlus = 49;
        public const int ctPlateRadiationCoeffZMinus = 50;
        public const int ctPlateRadiationAmbientZPlus = 51;
        public const int ctPlateRadiationAmbientZMinus = 52;
        public const int ctPlateHeatSource = 53;
        public const int ctPlateSoilStressSV = 54;
        public const int ctPlateSoilStressKO = 55;
        public const int ctPlateSoilStressSH = 56;
        public const int ctPlateSoilRatioOCR = 57;
        public const int ctPlateSoilRatioEO = 58;
        public const int ctPlateAgeAtFirstLoading = 59;

        // Entity Display Settings - Brick Contour Types
        public const int ctBrickNone = 0;
        public const int ctBrickAspectRatioMin = 1;
        public const int ctBrickAspectRatioMax = 2;
        public const int ctBrickVolume = 3;
        public const int ctBrickDeterminant = 4;
        public const int ctBrickInternalAngle = 5;
        public const int ctBrickMixedProduct = 6;
        public const int ctBrickDihedral = 7;
        public const int ctBrickAxis1 = 8;
        public const int ctBrickAxis2 = 9;
        public const int ctBrickAxis3 = 10;
        public const int ctBrickTemperature = 11;
        public const int ctBrickSupport = 12;
        public const int ctBrickPreStressX = 13;
        public const int ctBrickPreStressY = 14;
        public const int ctBrickPreStressZ = 15;
        public const int ctBrickPreStressMagnitude = 16;
        public const int ctBrickPreStrainX = 17;
        public const int ctBrickPreStrainY = 18;
        public const int ctBrickPreStrainZ = 19;
        public const int ctBrickPreStrainMagnitude = 20;
        public const int ctBrickNormalPressure = 21;
        public const int ctBrickGlobalPressure = 22;
        public const int ctBrickGlobalPressureX = 23;
        public const int ctBrickGlobalPressureY = 24;
        public const int ctBrickGlobalPressureZ = 25;
        public const int ctBrickShearX = 26;
        public const int ctBrickShearY = 27;
        public const int ctBrickShearMagnitude = 28;
        public const int ctBrickNSMass = 29;
        public const int ctBrickDynamicFactor = 30;
        public const int ctBrickConvectionCoeff = 31;
        public const int ctBrickConvectionAmbient = 32;
        public const int ctBrickRaditionCoeff = 33;
        public const int ctBrickRadiationAmbient = 34;
        public const int ctBrickHeatFlux = 35;
        public const int ctBrickHeatSource = 36;
        public const int ctBrickSoilStressSV = 37;
        public const int ctBrickSoilStressKO = 38;
        public const int ctBrickSoilStressSH = 39;
        public const int ctBrickSoilRatioOCR = 40;
        public const int ctBrickSoilRatioEO = 41;
        public const int ctBrickAgeAtFirstLoading = 42;

        // Beam/Plate/Brick Result Display Type - INDEXED BY ipResultType
        public const int rtAsNone = 0;
        public const int rtAsContour = 1;
        public const int rtAsDiagram = 2;
        public const int rtAsVector = 3;

        // Node Output Display Quantity - Indexed by ipResultQuantity
        public const int icDispC = 101;
        public const int icVelC = 102;
        public const int icAccC = 103;
        public const int icPhaseC = 104;
        public const int icReactC = 105;
        public const int icTempC = 106;
        public const int icNodeForceC = 107;
        public const int icNodeFluxC = 108;

        // Beam Output Display Quantity - Indexed by ipResultQuantity
        public const int icBeamForceC = 201;
        public const int icBeamStrainC = 202;
        public const int icBeamStressC = 203;
        public const int icBeamCreepStrainC = 204;
        public const int icBeamEnergyC = 205;
        public const int icBeamFluxC = 206;
        public const int icBeamTGradC = 207;

        // Plate Output Display Quantity - Indexed by ipResultQuantity
        public const int icPlateForceC = 301;
        public const int icPlateMomentC = 302;
        public const int icPlateStressC = 303;
        public const int icPlateStrainC = 304;
        public const int icPlateCurvatureC = 305;
        public const int icPlateCreepStrainC = 306;
        public const int icPlateEnergyC = 307;
        public const int icPlateFluxC = 308;
        public const int icPlateTGradC = 309;

        // Brick Output Display Quantity - Indexed by ipResultQuantity
        public const int icBrickStressC = 401;
        public const int icBrickStrainC = 402;
        public const int icBrickCreepStrainC = 403;
        public const int icBrickEnergyC = 404;
        public const int icBrickFluxC = 405;
        public const int icBrickTGradC = 406;

        // Vector Styles - Indexed by ipVectorStyle
        public const int vtVectorComponent = 0;
        public const int vtVectorTranslationMag = 1;
        public const int vtVectorRotationMag = 2;

        // Result Display Indexes
        public const int ipResultType = 0;
        public const int ipResultQuantity = 1;
        public const int ipResultAxis = 2;
        public const int ipResultComponent = 3;
        public const int ipResultSurface = 4;
        public const int ipVectorStyle = 5;
        public const int ipDiagram1 = 7;
        public const int ipDiagram2 = 8;
        public const int ipDiagram3 = 9;
        public const int ipDiagram4 = 10;
        public const int ipDiagram5 = 11;
        public const int ipDiagram6 = 12;
        public const int ipVector1 = 7;
        public const int ipVector2 = 8;
        public const int ipVector3 = 9;
        public const int ipVector4 = 10;
        public const int ipVector5 = 11;
        public const int ipVector6 = 12;

        // Displacement Scales
        public const int dsPercent = 0;
        public const int dsAbsolute = 1;

        // User Contour File Types
        public const int ucNode = 0;
        public const int ucElement = 1;

        // Utility
        public const int ipRadian = 0;
        public const int ipDegree = 1;

        // Result Options
        public const int ipResOptsBeamEnvelope = 0;
        public const int ipResOptsRotationUnit = 1;
        public const int ipResOptsHRADisplacement = 2;
        public const int ipResOptsHRAVelocity = 3;
        public const int ipResOptsHRAAcceleration = 4;
        public const int ipResOptsStageDisplacement = 5;
        public const int ipResOptsStrainUnit = 6;

        // Result Options - Strain Units
        public const int suUnit = 0;
        public const int suPercent = 1;
        public const int suMicro = 2;

        // Result Options - HRA
        public const int hrRelative = 0;
        public const int hrTotal = 1;

        // Result Options - Staging
        public const int sdBirthStage = 0;
        public const int sdInitial = 1;

        // Result Options - Beam Envelopes
        public const int bePrincipal = 0;
        public const int beLocal = 1;

        // Tool Options - Doubles
        public const int ipToolOptsElementTol = 0;
        public const int ipToolOptsGeometryAccuracy = 1;
        public const int ipToolOptsGeometryFeatureLength = 2;

        // Tool Options - Integers
        public const int ipToolOptsElementTolType = 0;
        public const int ipToolOptsGeometryAccuracyType = 1;
        public const int ipToolOptsGeometryFeatureType = 2;
        public const int ipToolOptsZipMesh = 3;
        public const int ipToolOptsNodeCoordinate = 4;
        public const int ipToolOptsNodeAttributeKeep = 5;
        public const int ipToolOptsAllowZeroLengthLinks = 6;
        public const int ipToolOptsAllowZeroLengthBeams = 7;
        public const int ipToolOptsAllowSameProperty = 8;
        public const int ipToolOptsCompatibleTriangle = 9;
        public const int ipToolOptsSubdivideBeams = 10;
        public const int ipToolOptsPlateAxisAlign = 11;
        public const int ipToolOptsCopyMode = 12;
        public const int ipToolOptsAutoCreateProperties = 13;

        // Tool Options - Mesh Zipping
        public const int zmAsNeeded = 0;
        public const int zmOnSave = 1;
        public const int zmOnRequest = 2;

        // Tool Options - Copy Mode
        public const int cmRoot = 0;
        public const int cmSibling = 1;

        // Tool Options - Axis Alignment
        public const int paCentroid = 0;
        public const int paCurvilinear = 1;

        // Axis Definitions
        public const int axLocalX = 1;
        public const int axLocalY = 2;
        public const int axPrincipal1 = 1;
        public const int axPrincipal2 = 2;
        public const int axBeamPrincipal = 0;
        public const int axBeamLocal = 1;

        // Beam Taper
        public const int btSymm = 0;
        public const int btTop = 1;
        public const int btBottom = 2;

        // Pre-load
        public const int plBeamPreTension = 0;
        public const int plBeamPreStrain = 1;
        public const int plPlatePreStress = 0;
        public const int plPlatePreStrain = 1;
        public const int plBrickPreStress = 0;
        public const int plBrickPreStrain = 1;

        // Attachment Attribute
        public const int alRigid = 0;
        public const int alFlexible = 1;
        public const int alDirect = 2;
        public const int alMoment = 0;
        public const int alPinned = 1;

        // Thermal
        public const int ipConvection = 0;
        public const int ipRadiation = 0;
        public const int ipAmbient = 1;

        // LTA Methods
        public const int ltWilson = 0;
        public const int ltNewmark = 1;

        // Spectral
        public const int stResponse = 0;
        public const int stPSD = 1;

        // Spectral Results Sign
        public const int rsAuto = 0;
        public const int rsAbsolute = 1;

        // LTA
        public const int stFullSystem = 0;
        public const int stSuperposition = 1;

        // Attach Parts
        public const int ipDoEnds = 0;
        public const int ipDoEdges = 1;
        public const int ipDoFaces = 2;
        public const int ipSelectedOnly = 3;
        public const int ipDeleteExisting = 4;
        public const int ipAllBrickFaces = 5;
        public const int ipAngleDelta = 0;

        // Modal Reactions
        public const int mrElementForce = 0;
        public const int mrInertiaForce = 1;

        // Transient Initial Conditions
        public const int icAppliedVectors = 0;
        public const int icNodalVelocity = 1;
        public const int icFromFile = 2;

        // Transient-Quasi Temperature
        public const int ttNodalTemp = 0;
        public const int ttFromFile = 1;

        // Envelopes
        public const int etLimitEnvelopeMin = 0;
        public const int etLimitEnvelopeMax = 1;
        public const int etLimitEnvelopeAbs = 2;
        public const int etCombEnvelopeMin = 3;
        public const int etCombEnvelopeMax = 4;
        public const int etFactEnvelopeMin = 5;
        public const int etFactEnvelopeMax = 6;
        public const int esCombEnvelopeOn = 0;
        public const int esCombEnvelopeOff = 1;
        public const int esCombEnvelopeCheck = 2;
        public const int stExclusiveOR = 0;
        public const int stExclusiveAND = 1;

        // Frequency Table Units
        public const int fuNone = 0;
        public const int fuDispResponse = 1;
        public const int fuVelResponse = 2;
        public const int fuAccelResponse = 3;
        public const int fuDispPSD = 4;
        public const int fuVelPSD = 5;
        public const int fuAccelPSD = 6;

        // Temp/Time Types
        public const int mtElastic = 0;
        public const int mtPlastic = 1;

        // Material Hardening Types
        public const int htIsotropic = 0;
        public const int htKinematic = 1;
        public const int htTakeda = 2;

        // Spring-damper
        public const int ipSpringAxialStiff = 0;
        public const int ipSpringLateralStiff = 1;
        public const int ipSpringTorsionStiff = 2;
        public const int ipSpringAxialDamp = 3;
        public const int ipSpringLateralDamp = 4;
        public const int ipSpringTorsionDamp = 5;
        public const int ipSpringMass = 6;

        // Truss
        public const int ipTrussIncludeTorsion = 0;

        // Cable
        public const int ipCableSegments = 0;

        // Cutoff Bar
        public const int ipCutoffTension = 0;
        public const int ipCutoffCompression = 1;

        // Contact
        public const int cfElastic = 0;
        public const int cfPlastic = 1;
        public const int cyRectangular = 0;
        public const int cyElliptical = 1;

        // Ply Material - Integers
        public const int ipPlyWeaveType = 0;
        public const int wtPlyUniDirectional = 0;
        public const int wtPlyBiDirectional = 1;
        public const int wtPlyTriDirectional = 2;
        public const int wtPlyQuasiIsotropic = 3;

        // Ply Material - Doubles
        public const int ipPlyModulus1 = 0;
        public const int ipPlyModulus2 = 1;
        public const int ipPlyPoisson = 2;
        public const int ipPlyShear12 = 3;
        public const int ipPlyShear13 = 4;
        public const int ipPlyShear23 = 5;
        public const int ipPlyAlpha1 = 6;
        public const int ipPlyAlpha2 = 7;
        public const int ipPlyDensity = 8;
        public const int ipPlyThickness = 9;
        public const int ipPlyS1Tension = 10;
        public const int ipPlyS2Tension = 11;
        public const int ipPlyS1Compression = 12;
        public const int ipPlyS2Compression = 13;
        public const int ipPlySShear = 14;
        public const int ipPlyE1Tension = 15;
        public const int ipPlyE2Tension = 16;
        public const int ipPlyE1Compression = 17;
        public const int ipPlyE2Compression = 18;
        public const int ipPlyEShear = 19;
        public const int ipPlyInterLaminaShear = 20;

        // Laminate Material
        public const int ipLaminateViscosity = 0;
        public const int ipLaminateDampingRatio = 1;
        public const int ipLaminateConductivity1 = 2;
        public const int ipLaminateConductivity2 = 3;
        public const int ipLaminateSpecificHeat = 4;
        public const int ipLaminateDensity = 5;
        public const int ipLaminateAlphax = 6;
        public const int ipLaminateAlphay = 7;
        public const int ipLaminateAlphaxy = 8;
        public const int ipLaminateBetax = 9;
        public const int ipLaminateBetay = 10;
        public const int ipLaminateBetaxy = 11;
        public const int ipLaminateModulusx = 12;
        public const int ipLaminateModulusy = 13;
        public const int ipLaminateShearxy = 14;
        public const int ipLaminatePoissonxy = 15;
        public const int ipLaminatePoissonyx = 16;
        public const int ipLaminateThickness = 17;

        // Laminate Plies
        public const int ipLaminatePlyAngle = 0;
        public const int ipLaminatePlyThickness = 1;

        // Laminate Matrices
        public const int ipLaminateIgnoreCoupling = 0;
        public const int ipLaminateAutoTransverseShear = 1;

        // Concrete Reinforcement Layouts - Integers
        public const int ipReoLayoutType = 0;
        public const int ipReoColour13 = 1;
        public const int ipReoColour24 = 2;
        public const int ipReoCalcMethod = 3;
        public const int ipReoConsiderMembrane = 4;
        public const int ipReoAllowCompressionReo = 5;
        public const int ipReoCode = 6;
        public const int ipReoLimitConcreteStrain = 7;
        public const int crReoSymmetric = 0;
        public const int crReoAntiSymmetric = 1;
        public const int crReoSimplified = 0;
        public const int crReoElastoPlasticIter = 1;

        // Concrete Reinforcement Layouts - Doubles
        public const int ipReoDiam1 = 0;
        public const int ipReoDiam2 = 1;
        public const int ipReoDiam3 = 2;
        public const int ipReoDiam4 = 3;
        public const int ipReoCover1 = 4;
        public const int ipReoCover2 = 5;
        public const int ipReoSpacing1 = 6;
        public const int ipReoSpacing2 = 7;
        public const int ipReoSpacing3 = 8;
        public const int ipReoSpacing4 = 9;
        public const int ipReoConcreteModulus = 10;
        public const int ipReoConcreteStrain = 11;
        public const int ipReoConcreteStress = 12;
        public const int ipReoConcretePhi = 13;
        public const int ipReoConcreteGamma = 14;
        public const int ipReoSteelModulus = 15;
        public const int ipReoSteelStress = 16;
        public const int ipReoSteelGamma = 17;
        public const int ipReoSteelMinArea = 18;

        // Creep Hardening
        public const int ipCreepHardeningType = 0;
        public const int ipCreepHardeningCyclic = 1;
        public const int crHardeningTime = 0;
        public const int crHardeningStrain = 1;

        // Hyperbolic Creep - Doubles
        public const int ipCreepHyberbolicAlpha = 0;
        public const int ipCreepHyperbolicBeta = 1;
        public const int ipCreepHyperbolicDelta = 2;
        public const int ipCreepHyperbolicPhi = 3;

        // Hyperbolic Creep - Integers
        public const int ipCreepHyperbolicTimeTable = 0;
        public const int ipCreepHyperbolicConstModulus = 1;

        // Visco-elastic Creep - Integers
        public const int ipCreepViscoTimeTable = 0;
        public const int ipCreepViscoTempTable = 1;

        // Visco-elastic Creep - Doubles
        public const int ipCreepViscoDamper = 0;
        public const int ipCreepViscoStiffness = 1;

        // Creep Concrete Functions
        public const int cfCreepFunction = 0;
        public const int cfRelaxationFunction = 1;

        // Creep Shrinkage
        public const int crCreepShrinkageTable = 0;
        public const int crCreepShrinkageFormula = 1;
        public const int ipCreepShrinkageAlpha = 0;
        public const int ipCreepShrinkageBeta = 1;
        public const int ipCreepShrinkageDelta = 2;
        public const int ipCreepShrinkageStrain = 3;

        // Creep Temperature - Integers
        public const int ipIncludeCreepTemperature = 0;
        public const int ipIncludeRateTemperature = 1;
        public const int ipIncludeShrinkageTemperature = 2;

        // Creep Temperature - Doubles
        public const int ipCreepCAAge = 0;
        public const int ipCreepTRefAge = 1;
        public const int ipCreepCCCreep = 2;
        public const int ipCreepTRefCreep = 3;
        public const int ipCreepCAShrink = 4;
        public const int ipCreepTRefShrink = 5;

        // Cement Curing - Integers
        public const int ipCreepIncludeCuring = 0;
        public const int ipCreepCuringTimeTable = 1;
        public const int ipCreepCuringType = 2;
        public const int ctCuringRapid = 0;
        public const int ctCuringNormal = 1;
        public const int ctCuringSlow = 2;

        // Cement Curing - Doubles
        public const int ipCreepCuringCT = 0;
        public const int ipCreepCuringTRef = 1;
        public const int ipCreepCuringT0 = 2;

        // Stage Data
        public const int ipStageMorph = 0;
        public const int ipStageMovedFixedNodes = 1;
        public const int ipStageRotateClusters = 2;

        // Node Response Variables
        public const int reNodeDisplacement = 0;
        public const int reNodeReaction = 1;

        // Beam Response Variables
        public const int ipBeamResponseSF1 = 0;
        public const int ipBeamResponseSF2 = 1;
        public const int ipBeamResponseAxial = 2;
        public const int ipBeamResponseBM1 = 3;
        public const int ipBeamResponseBM2 = 4;
        public const int ipBeamResponseTorque = 5;

        // Plate Response Variables
        public const int rePlateForce = 0;
        public const int rePlateMoment = 1;

        // Pipe Properties
        public const int ipPipeFlexibility = 0;
        public const int ipPipeFluidDensity = 1;
        public const int ipPipeOuterDiameter = 2;
        public const int ipPipeThickness = 3;

        // Connection Properties
        public const int ipConnectionShear1 = 0;
        public const int ipConnectionShear2 = 1;
        public const int ipConnectionAxial = 2;
        public const int ipConnectionBend1 = 3;
        public const int ipConnectionBend2 = 4;
        public const int ipConnectionTorque = 5;

        // Beam Materials
        public const int ipBeamModulus = 0;
        public const int ipBeamShear = 1;
        public const int ipBeamPoisson = 2;
        public const int ipBeamDensity = 3;
        public const int ipBeamAlpha = 4;
        public const int ipBeamViscosity = 5;
        public const int ipBeamDampingRatio = 6;
        public const int ipBeamConductivity = 7;
        public const int ipBeamSpecificHeat = 8;

        // Plate Isotropic Materials
        public const int ipPlateIsoModulus = 0;
        public const int ipPlateIsoPoisson = 1;
        public const int ipPlateIsoDensity = 2;
        public const int ipPlateIsoAlpha = 3;
        public const int ipPlateIsoViscosity = 4;
        public const int ipPlateIsoDampingRatio = 5;
        public const int ipPlateIsoConductivity = 6;
        public const int ipPlateIsoSpecificHeat = 7;

        // Brick Isotropic Materials
        public const int ipBrickIsoModulus = 0;
        public const int ipBrickIsoPoisson = 1;
        public const int ipBrickIsoDensity = 2;
        public const int ipBrickIsoAlpha = 3;
        public const int ipBrickIsoViscosity = 4;
        public const int ipBrickIsoDampingRatio = 5;
        public const int ipBrickIsoConductivity = 6;
        public const int ipBrickIsoSpecificHeat = 7;

        // Plate Orthotropic Materials
        public const int ipPlateOrthoModulus1 = 0;
        public const int ipPlateOrthoModulus2 = 1;
        public const int ipPlateOrthoModulus3 = 2;
        public const int ipPlateOrthoShear12 = 3;
        public const int ipPlateOrthoShear23 = 4;
        public const int ipPlateOrthoShear31 = 5;
        public const int ipPlateOrthoPoisson12 = 6;
        public const int ipPlateOrthoPoisson23 = 7;
        public const int ipPlateOrthoPoisson31 = 8;
        public const int ipPlateOrthoDensity = 9;
        public const int ipPlateOrthoAlpha1 = 10;
        public const int ipPlateOrthoAlpha2 = 11;
        public const int ipPlateOrthoAlpha3 = 12;
        public const int ipPlateOrthoViscosity = 13;
        public const int ipPlateOrthoDampingRatio = 14;
        public const int ipPlateOrthoConductivity1 = 15;
        public const int ipPlateOrthoConductivity2 = 16;
        public const int ipPlateOrthoSpecificHeat = 17;

        // Brick Orthotropic Materials
        public const int ipBrickOrthoModulus1 = 0;
        public const int ipBrickOrthoModulus2 = 1;
        public const int ipBrickOrthoModulus3 = 2;
        public const int ipBrickOrthoShear12 = 3;
        public const int ipBrickOrthoShear23 = 4;
        public const int ipBrickOrthoShear31 = 5;
        public const int ipBrickOrthoPoisson12 = 6;
        public const int ipBrickOrthoPoisson23 = 7;
        public const int ipBrickOrthoPoisson31 = 8;
        public const int ipBrickOrthoDensity = 9;
        public const int ipBrickOrthoAlpha1 = 10;
        public const int ipBrickOrthoAlpha2 = 11;
        public const int ipBrickOrthoAlpha3 = 12;
        public const int ipBrickOrthoViscosity = 13;
        public const int ipBrickOrthoDampingRatio = 14;
        public const int ipBrickOrthoConductivity1 = 15;
        public const int ipBrickOrthoConductivity2 = 16;
        public const int ipBrickOrthoConductivity3 = 17;
        public const int ipBrickOrthoSpecificHeat = 18;

        // Plate Anisotropic Materials

        // 0..9 ansi matrix
        public const int ipPlateAnisoTransShear1 = 10;
        public const int ipPlateAnisoTransShear2 = 11;
        public const int ipPlateAnisoTransShear3 = 12;
        public const int ipPlateAnisoDensity = 13;
        public const int ipPlateAnisoAlpha1 = 14;
        public const int ipPlateAnisoAlpha2 = 15;
        public const int ipPlateAnisoAlpha3 = 16;
        public const int ipPlateAnisoAlpha12 = 17;
        public const int ipPlateAnisoViscosity = 18;
        public const int ipPlateAnisoDampingRatio = 19;
        public const int ipPlateAnisoConductivity1 = 20;
        public const int ipPlateAnisoConductivity2 = 21;
        public const int ipPlateAnisoSpecificHeat = 22;

        // Plate User Defined Materials

        // 0..20 user matrix
        public const int ipPlateUserTransShearxz = 21;
        public const int ipPlateUserTransShearyz = 22;
        public const int ipPlateUserTransShearcz = 23;
        public const int ipPlateUserDensity = 24;
        public const int ipPlateUserAlphax = 25;
        public const int ipPlateUserAlphay = 26;
        public const int ipPlateUserAlphaxy = 27;
        public const int ipPlateUserBetax = 28;
        public const int ipPlateUserBetay = 29;
        public const int ipPlateUserBetaxy = 30;
        public const int ipPlateUserViscosity = 31;
        public const int ipPlateUserDampingRatio = 32;
        public const int ipPlateUserConductivity1 = 33;
        public const int ipPlateUserConductivity2 = 34;
        public const int ipPlateUserSpecificHeat = 35;

        // Brick Anisotropic Materials

        // 0..20 user matrix
        public const int ipBrickUserDensity = 21;
        public const int ipBrickUserAlpha1 = 22;
        public const int ipBrickUserAlpha2 = 23;
        public const int ipBrickUserAlpha3 = 24;
        public const int ipBrickUserAlpha12 = 25;
        public const int ipBrickUserAlpha23 = 26;
        public const int ipBrickUserAlpha31 = 27;
        public const int ipBrickUserViscosity = 28;
        public const int ipBrickUserDampingRatio = 29;
        public const int ipBrickUserConductivity1 = 30;
        public const int ipBrickUserConductivity2 = 31;
        public const int ipBrickUserConductivity3 = 32;
        public const int ipBrickUserSpecificHeat = 33;

        // Duncan-Chang Soil Materials - Integers
        public const int ipSoilDCUsePoisson = 0;
        public const int ipSoilDCSetLevel = 1;

        // Duncan-Chang Soil Materials - Doubles
        public const int ipSoilDCModulusK = 0;
        public const int ipSoilDCModulusKUR = 1;
        public const int ipSoilDCModulusN = 2;
        public const int ipSoilDCPoisson = 3;
        public const int ipSoilDCBulkK = 4;
        public const int ipSoilDCBulkM = 5;
        public const int ipSoilDCFrictionAngle = 6;
        public const int ipSoilDCDeltaAngle = 7;
        public const int ipSoilDCCohesion = 8;
        public const int ipSoilDCFailureRatio = 9;
        public const int ipSoilDCFailureMod = 10;
        public const int ipSoilDCReferenceP = 11;
        public const int ipSoilDCDensity = 12;
        public const int ipSoilDCHorizontalRatio = 13;
        public const int ipSoilDCConductivity = 14;
        public const int ipSoilDCSpecificHeat = 15;
        public const int ipSoilDCFluidLevel = 16;

        // Cam-Clay Soil Materials - Integers
        public const int ipSoilCCUsePoisson = 0;
        public const int ipSoilCCDrainedState = 1;
        public const int ipSoilCCUseOCR = 2;
        public const int ipSoilCCSetLevel = 3;

        // Cam-Clay Soil Materials - Doubles
        public const int ipSoilCCCriticalStateLine = 0;
        public const int ipSoilCCConsolidationLine = 1;
        public const int ipSoilCCSwellingLine = 2;
        public const int ipSoilCCDensity = 3;
        public const int ipSoilCCPoisson = 4;
        public const int ipSoilCCModulusG = 5;
        public const int ipSoilCCModulusB = 6;
        public const int ipSoilCCHorizontalRatio = 7;
        public const int ipSoilCCER = 8;
        public const int ipSoilCCPR = 9;
        public const int ipSoilCCPC0 = 10;
        public const int ipSoilCCOCR = 11;
        public const int ipSoilCCConductivity = 12;
        public const int ipSoilCCSpecificHeat = 13;
        public const int ipSoilCCFluidLevel = 14;

        // Mohr-Coulomb Soil Materials - Integers
        public const int ipSoilMCSetLevel = 0;

        // Mohr-Coulomb Soil Materials - Doubles
        public const int ipSoilMCModulus = 0;
        public const int ipSoilMCPoisson = 1;
        public const int ipSoilMCDensity = 2;
        public const int ipSoilMCHorizontalRatio = 3;
        public const int ipSoilMCER = 4;
        public const int ipSoilMCConductivity = 5;
        public const int ipSoilMCSpecificHeat = 6;
        public const int ipSoilMCFluidLevel = 7;
        public const int ipSoilMCCohesion = 8;
        public const int ipSoilMCFrictionAngle = 9;

        // Drucker-Prager Soil Materials - Integers
        public const int ipSoilDPSetLevel = 0;

        // Drucker-Prager Soil Materials - Doubles
        public const int ipSoilDPModulus = 0;
        public const int ipSoilDPPoisson = 1;
        public const int ipSoilDPDensity = 2;
        public const int ipSoilDPHorizontalRatio = 3;
        public const int ipSoilDPER = 4;
        public const int ipSoilDPConductivity = 5;
        public const int ipSoilDPSpecificHeat = 6;
        public const int ipSoilDPFluidLevel = 7;
        public const int ipSoilDPCohesion = 8;
        public const int ipSoilDPFrictionAngle = 9;

        // Linear Elastic Soil Materials - Integers
        public const int ipSoilLSSetLevel = 0;

        // Linear Elastic Soil Materials - Doubles
        public const int ipSoilLSModulus = 0;
        public const int ipSoilLSPoisson = 1;
        public const int ipSoilLSDensity = 2;
        public const int ipSoilLSHorizontalRatio = 3;
        public const int ipSoilLSER = 4;
        public const int ipSoilLSConductivity = 5;
        public const int ipSoilLSSpecificHeat = 6;
        public const int ipSoilLSFluidLevel = 7;

        // Fluid Materials
        public const int ipFluidModulus = 0;
        public const int ipFluidPenaltyParam = 1;
        public const int ipFluidDensity = 2;
        public const int ipFluidAlpha = 3;
        public const int ipFluidViscosity = 4;
        public const int ipFluidDampingRatio = 5;
        public const int ipFluidConductivity = 6;
        public const int ipFluidSpecificHeat = 7;

        // Mohr-Coulomb, Drucker-Prager
        public const int ipFrictionAngle = 0;
        public const int ipCohesion = 1;

        // Rubber Materials
        public const int ipRubberBulk = 0;
        public const int ipRubberDensity = 1;
        public const int ipRubberAlpha = 2;
        public const int ipRubberViscosity = 3;
        public const int ipRubberDampingRatio = 4;
        public const int ipRubberConductivity = 5;
        public const int ipRubberSpecificHeat = 6;
        public const int ipRubberConstC1 = 7;

        // Load Case Types
        public const int ltLoadCase = 0;
        public const int ltSeismicCase = 1;
        public const int ltSpectralCase = 2;

        // Polygon to Face - Doubles
        public const int ipPolyToFaceEdgeTolerance = 0;

        // Polygon to Face - Integers
        public const int ipPolyToFaceFaceID = 0;
        public const int ipPolyToFaceGroupIndex = 1;
        public const int ipPolyToFacePropertyNumber = 2;
        public const int ipPolyToFaceDeleteBeams = 3;
        public const int ipPolyToFaceKeepSelected = 4;

        // Beam Property
        public const int ipBeamPropBeamType = 0;
        public const int ipBeamPropSectionType = 1;
        public const int ipBeamPropMirrorType = 2;
        public const int ipBeamPropCompatibleTwist = 3;

        // Element Axis Types
        public const int axUCS = 0;
        public const int axLocal = 1;

        // Load Path Template - Integers
        public const int ipLPTColour = 0;
        public const int ipLPTNumLanes = 1;
        public const int ipLPTMultiLaneType = 2;
        public const int lpAllSameFactors = 0;
        public const int lpAllDifferentFactors = 1;

        // Load Path Template - Doubles
        public const int ipLPTTolerance = 0;
        public const int ipLPTMinLaneWidth = 1;

        // Load Path Vehicle - Integers
        public const int ipLPTVehicleInstance = 0;
        public const int ipLPTVehicleDirection = 1;
        public const int lpVehicleSingleLane = 0;
        public const int lpVehicleDoubleLane = 1;
        public const int lpVehicleForward = 0;
        public const int lpVehicleBackward = 1;

        // Load Path Vehicle - Doubles
        public const int ipLPTVehicleVelocity = 0;
        public const int ipLPTVehicleStartTime = 1;

        // Load Path Template Forces - Integers
        public const int ipLPTMobility = 0;
        public const int ipLPTAxisSystem = 1;
        public const int ipLPTAdjacency = 2;
        public const int ipLPTCentrifugal = 3;
        public const int lpPointForceMobilityGrouped = 0;
        public const int lpPointForceMobilityFloating = 1;
        public const int lpDistrForceMobilityGrouped = 0;
        public const int lpDistrForceMobilityLeading = 1;
        public const int lpDistrForceMobilityTrailing = 2;
        public const int lpDistrForceMobilityFullLength = 3;
        public const int lpDistrForceMobilityFloating = 4;
        public const int lpAxisLocal = 0;
        public const int lpAxisGlobal = 1;

        // Load Path Templates - Integers
        public const int ipLPTLimitK1 = 0;
        public const int ipLPTLengthUnit = 1;
        public const int ipLPTForceUnit = 2;

        // Load Path Templates - Doubles
        public const int ipLPTMinK1 = 0;
        public const int ipLPTMaxK1 = 1;

        // Combined Result Files
        public const int rfCombFactors = 0;
        public const int rfCombSRSS = 1;

        // Load Path
        public const int ipLoadPathCase = 0;
        public const int ipLoadPathTemplate = 1;
        public const int ipLoadPathShape = 2;
        public const int ipLoadPathSurface = 3;
        public const int ipLoadPathTarget = 4;
        public const int ipLoadPathDivisions = 5;
        public const int lpShapeStraight = 0;
        public const int lpShapeCurved = 1;
        public const int lpShapeQuadratic = 2;
        public const int lpSurfaceFlat = 0;
        public const int lpSurfaceCurved = 1;

        // Animation
        public const int ipAniParentHandle = 0;
        public const int ipAniCase = 1;
        public const int ipNumFrames = 2;
        public const int ipAniWidth = 3;
        public const int ipAniHeight = 4;
        public const int ipAniType = 5;
        public const int kAniSAF = 0;
        public const int kAniEXE = 1;
        public const int kAniAVI = 2;

        // Custom Result Files - NODEDISP, NODEREACT
        public const int ipNodeResFileDX = 0;
        public const int ipNodeResFileDY = 1;
        public const int ipNodeResFileDZ = 2;
        public const int ipNodeResFileRX = 3;
        public const int ipNodeResFileRY = 4;
        public const int ipNodeResFileRZ = 5;

        // Custom Result Files - NODETEMP, NODEFLUX
        public const int ipNodeResTemp = 0;

        // Custom Result Files - BEAMFORCE
        public const int ipBeamResFileSF1 = 0;
        public const int ipBeamResFileSF2 = 1;
        public const int ipBeamResFileAxial = 2;
        public const int ipBeamResFileBM1 = 3;
        public const int ipBeamResFileBM2 = 4;
        public const int ipBeamResFileTorque = 5;
        public const int kBeamResFileForceSize = 6;

        // Custom Result Files - BEAMSTRAIN
        public const int ipBeamResFileAxialStrain = 2;
        public const int ipBeamResFileCurvature1 = 3;
        public const int ipBeamResFileCurvature2 = 4;
        public const int ipBeamResFileTwist = 5;
        public const int kBeamResFileStrainSize = 6;

        // Custom Result Files - BEAMNODEREACT
        public const int ipBeamResFileFX = 0;
        public const int ipBeamResFileFY = 1;
        public const int ipBeamResFileFZ = 2;
        public const int ipBeamResFileMX = 3;
        public const int ipBeamResFileMY = 4;
        public const int ipBeamResFileMZ = 5;
        public const int kBeamResFileReactSize = 6;

        // Custom Result Files - BEAMFLUX
        public const int ipBeamResFileF = 0;
        public const int ipBeamResFileG = 1;
        public const int kBeamResFileFluxSize = 2;

        // Custom Result Files - PLATESTRESS for PlateShell - Local system
        public const int ipPlateShellResFileNxx = 0;
        public const int ipPlateShellResFileNyy = 1;
        public const int ipPlateShellResFileNxy = 2;
        public const int ipPlateShellResFileMxx = 3;
        public const int ipPlateShellResFileMyy = 4;
        public const int ipPlateShellResFileMxy = 5;
        public const int ipPlateShellResFileQxz = 6;
        public const int ipPlateShellResFileQyz = 7;
        public const int ipPlateShellResFileZMinusSxx = 8;
        public const int ipPlateShellResFileZMinusSyy = 9;
        public const int ipPlateShellResFileZMinusSxy = 10;
        public const int ipPlateShellResFileMidPlaneSxx = 11;
        public const int ipPlateShellResFileMidPlaneSyy = 12;
        public const int ipPlateShellResFileMidPlaneSxy = 13;
        public const int ipPlateShellResFileZPlusSxx = 14;
        public const int ipPlateShellResFileZPlusSyy = 15;
        public const int ipPlateShellResFileZPlusSxy = 16;
        public const int kPlateShellResFileStressSize = 17;

        // Custom Result Files - PLATESTRAIN for PlateShell - Local system
        public const int ipPlateShellResFileExx = 0;
        public const int ipPlateShellResFileEyy = 1;
        public const int ipPlateShellResFileExy = 2;
        public const int ipPlateShellResFileEzz = 3;
        public const int ipPlateShellResFileKxx = 4;
        public const int ipPlateShellResFileKyy = 5;
        public const int ipPlateShellResFileKxy = 6;
        public const int ipPlateShellResFileTxz = 7;
        public const int ipPlateShellResFileTyz = 8;
        public const int ipPlateShellResFileStoredE = 9;
        public const int ipPlateShellResFileSpentE = 10;
        public const int kPlateShellResFileStrainSize = 11;

        // Custom Result Files - PLATESTRESS for 2D Plates - Global system
        public const int ipPlate2DResFileSXX = 0;
        public const int ipPlate2DResFileSYY = 1;
        public const int ipPlate2DResFileSXY = 2;
        public const int ipPlate2DResFileSZZ = 3;
        public const int kPlate2DResFileStressSize = 4;

        // Custom Result Files - PLATESTRAIN for 2D Plates - Global system
        public const int ipPlate2DResFileEXX = 0;
        public const int ipPlate2DResFileEYY = 1;
        public const int ipPlate2DResFileEXY = 2;
        public const int ipPlate2DResFileEZZ = 3;
        public const int ipPlate2DResFileStoredE = 4;
        public const int ipPlate2DResFileSpentE = 5;
        public const int kPlate2DResFileStrainSize = 6;

        // Custom Result Files - PLATESTRESS for Axi Plates - Axisymmetric system
        public const int ipPlateAxiResFileSRR = 0;
        public const int ipPlateAxiResFileSZZ = 1;
        public const int ipPlateAxiResFileSTT = 2;
        public const int ipPlateAxiResFileSRT = 3;
        public const int kPlateAxiResFileStressSize = 4;

        // Custom Result Files - PLATESTRAIN for Axi Plates - Axisymmetric system
        public const int ipPlateAxiResFileERR = 0;
        public const int ipPlateAxiResFileEZZ = 1;
        public const int ipPlateAxiResFileETT = 2;
        public const int ipPlateAxiResFileERT = 3;
        public const int ipPlateAxiResFileStoredE = 4;
        public const int ipPlateAxiResFileSpentE = 5;
        public const int kPlateAxiResFileStrainSize = 6;

        // Custom Result Files - PLATENODEREACT
        public const int ipPlateResFileFX = 0;
        public const int ipPlateResFileFY = 1;
        public const int ipPlateResFileFZ = 2;
        public const int ipPlateResFileMX = 3;
        public const int ipPlateResFileMY = 4;
        public const int ipPlateResFileMZ = 5;
        public const int kPlateResFileReactSize = 6;

        // Custom Result Files - PLATEFLUX
        public const int ipPlateResFileFxx = 0;
        public const int ipPlateResFileFyy = 1;
        public const int ipPlateResFileGxx = 2;
        public const int ipPlateResFileGyy = 3;
        public const int kPlateResFileFluxSize = 4;

        // Custom Result Files - BRICKSTRESS
        public const int ipBrickResFileSXX = 0;
        public const int ipBrickResFileSYY = 1;
        public const int ipBrickResFileSZZ = 2;
        public const int ipBrickResFileSXY = 3;
        public const int ipBrickResFileSYZ = 4;
        public const int ipBrickResFileSZX = 5;
        public const int kBrickResFileStressSize = 6;

        // Custom Result Files - BRICKSTRAIN
        public const int ipBrickResFileExx = 0;
        public const int ipBrickResFileEyy = 1;
        public const int ipBrickResFileEzz = 2;
        public const int ipBrickResFileExy = 3;
        public const int ipBrickResFileEyz = 4;
        public const int ipBrickResFileEzx = 5;
        public const int ipBrickResFileStoredE = 6;
        public const int ipBrickResFileSpentE = 7;
        public const int kBrickResFileStrainSize = 8;

        // Custom Result Files - BRICKNODEREACT
        public const int ipBrickResFileFX = 0;
        public const int ipBrickResFileFY = 1;
        public const int ipBrickResFileFZ = 2;
        public const int kBrickResFileReactSize = 3;

        // Custom Result Files - BRICKFLUX
        public const int ipBrickResFileFXX = 0;
        public const int ipBrickResFileFYY = 1;
        public const int ipBrickResFileFZZ = 2;
        public const int ipBrickResFileGXX = 3;
        public const int ipBrickResFileGYY = 4;
        public const int ipBrickResFileGZZ = 5;
        public const int kBrickResFileFluxSize = 6;

        // Edge Attachment Direction
        public const int adPlanar = 0;
        public const int adPlusZ = 1;
        public const int adMinusZ = 2;

        [DllImport("St7API.dll")]
        public static extern int St7Init();
        [DllImport("St7API.dll")]
        public static extern int St7Release();
        [DllImport("St7API.dll")]
        public static extern int St7APIVersion(ref int Major, ref int Minor, ref int Point);
        [DllImport("St7API.dll")]
        public static extern int St7OpenFile(int uID, string FileName, string ScratchPath);
        [DllImport("St7API.dll")]
        public static extern int St7CloseFile(int uID);
        [DllImport("St7API.dll")]
        public static extern int St7NewFile(int uID, string FileName, string ScratchPath);
        [DllImport("St7API.dll")]
        public static extern int St7SaveFile(int uID);
        [DllImport("St7API.dll")]
        public static extern int St7SaveFileTo(int uID, string FileName);
        [DllImport("St7API.dll")]
        public static extern int St7OpenResultFile(int uID, string FileName, string SpectralName, byte Combinations, ref int NumPrimary, ref int NumSecondary);
        [DllImport("St7API.dll")]
        public static extern int St7GenerateLSACombinations(int uID, ref int NumSecondary);
        [DllImport("St7API.dll")]
        public static extern int St7GenerateEnvelopes(int uID, ref int NumLimitEnvelopes, ref int NumCombinationEnvelopes, ref int NumFactorsEnvelopes);
        [DllImport("St7API.dll")]
        public static extern int St7CloseResultFile(int uID);
        [DllImport("St7API.dll")]
        public static extern int St7GetDisplayOptionsPath(StringBuilder ConfigPath, int MaxStringLen);
        [DllImport("St7API.dll")]
        public static extern int St7SetDisplayOptionsPath(string ConfigPath);
        [DllImport("St7API.dll")]
        public static extern int St7GetLibraryPath(StringBuilder LibraryPath, int MaxStringLen);
        [DllImport("St7API.dll")]
        public static extern int St7SetLibraryPath(string LibraryPath);
        [DllImport("St7API.dll")]
        public static extern int St7GetPath(StringBuilder St7Path, int MaxStringLen);
        [DllImport("St7API.dll")]
        public static extern int St7GetLastError();
        [DllImport("St7API.dll")]
        public static extern int St7GetAPIErrorString(int iErr, StringBuilder ErrorString, int MaxStringLen);
        [DllImport("St7API.dll")]
        public static extern int St7GetSolverErrorString(int iErr, StringBuilder ErrorString, int MaxStringLen);
        [DllImport("St7API.dll")]
        public static extern int St7TransformToUCS(int uID, int UCSId, double[] XYZ);
        [DllImport("St7API.dll")]
        public static extern int St7TransformToXYZ(int uID, int UCSId, double[] XYZ);
        [DllImport("St7API.dll")]
        public static extern int St7VectorTransformToUCS(int uID, int UCSId, double[] Position, double[] VXYZ);
        [DllImport("St7API.dll")]
        public static extern int St7VectorTransformToXYZ(int uID, int UCSId, double[] Position, double[] VXYZ);
        [DllImport("St7API.dll")]
        public static extern int St7GetCleanMeshData(int uID, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetCleanMeshData(int uID, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7CleanMesh(int uID);
        [DllImport("St7API.dll")]
        public static extern int St7DeleteUnusedNodes(int uID, ref int NumDeleted);
        [DllImport("St7API.dll")]
        public static extern int St7InvalidateElement(int uID, int Entity, int EltNum);
        [DllImport("St7API.dll")]
        public static extern int St7DeleteInvalidElements(int uID, int Entity, ref int NumDeleted);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlateUV(int uID, int PlateNum, double[] XYZ, double[] UV);
        [DllImport("St7API.dll")]
        public static extern int St7GetBrickUVW(int uID, int BrickNum, double[] XYZ, double[] UVW);
        [DllImport("St7API.dll")]
        public static extern int St7GetNumElementResultGaussPoints(int uID, int Entity, int NumNodes, ref int NumGauss);
        [DllImport("St7API.dll")]
        public static extern int St7ConvertElementResultNodeToGaussPoint(int uID, int Entity, int NumNodes, int NumColumns, double[] NodeDoubles, ref int NumGauss, double[] GaussDoubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetResultOptions(int uID, int[] Integers);
        [DllImport("St7API.dll")]
        public static extern int St7GetResultOptions(int uID, int[] Integers);
        [DllImport("St7API.dll")]
        public static extern int St7SetToolOptions(int uID, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetToolOptions(int uID, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7EnableModelStrainUnit(int uID);
        [DllImport("St7API.dll")]
        public static extern int St7DisableModelStrainUnit(int uID);
        [DllImport("St7API.dll")]
        public static extern int St7EnableModelRotationUnit(int uID);
        [DllImport("St7API.dll")]
        public static extern int St7DisableModelRotationUnit(int uID);
        [DllImport("St7API.dll")]
        public static extern int St7EnableModelRCUnit(int uID);
        [DllImport("St7API.dll")]
        public static extern int St7DisableModelRCUnit(int uID);
        [DllImport("St7API.dll")]
        public static extern int St7SetEntitySelectState(int uID, int Entity, int EntityNum, int EndEdgeFace, byte Selected);
        [DllImport("St7API.dll")]
        public static extern int St7GetEntitySelectState(int uID, int Entity, int EntityNum, int EndEdgeFace, ref byte Selected);
        [DllImport("St7API.dll")]
        public static extern int St7CreateModelWindow(int uID);
        [DllImport("St7API.dll")]
        public static extern int St7DestroyModelWindow(int uID);
        [DllImport("St7API.dll")]
        public static extern int St7GetModelWindowState(int uID, ref int State);
        [DllImport("St7API.dll")]
        public static extern int St7GetModelWindowHandle(int uID, ref int Handle);
        [DllImport("St7API.dll")]
        public static extern int St7SetModelWindowParent(int uID, int Handle);
        [DllImport("St7API.dll")]
        public static extern int St7ShowModelWindow(int uID);
        [DllImport("St7API.dll")]
        public static extern int St7HideModelWindow(int uID);
        [DllImport("St7API.dll")]
        public static extern int St7RedrawModel(int uID, byte Rescale);
        [DllImport("St7API.dll")]
        public static extern int St7ClearModelWindow(int uID);
        [DllImport("St7API.dll")]
        public static extern int St7ShowWindowPopUp(int uID, int MenuGroup);
        [DllImport("St7API.dll")]
        public static extern int St7HideWindowPopUp(int uID, int MenuGroup);
        [DllImport("St7API.dll")]
        public static extern int St7ShowWindowTopPanel(int uID);
        [DllImport("St7API.dll")]
        public static extern int St7HideWindowTopPanel(int uID);
        [DllImport("St7API.dll")]
        public static extern int St7ShowWindowToolbar(int uID);
        [DllImport("St7API.dll")]
        public static extern int St7HideWindowToolbar(int uID);
        [DllImport("St7API.dll")]
        public static extern int St7ShowWindowStatusBar(int uID);
        [DllImport("St7API.dll")]
        public static extern int St7HideWindowStatusBar(int uID);
        [DllImport("St7API.dll")]
        public static extern int St7ShowSelectionToolBar(int uID);
        [DllImport("St7API.dll")]
        public static extern int St7HideSelectionToolBar(int uID);
        [DllImport("St7API.dll")]
        public static extern int St7SetSelectionToolBarPosition(int uID, int Left, int Top);
        [DllImport("St7API.dll")]
        public static extern int St7GetSelectionToolBarPosition(int uID, ref int Left, ref int Top);
        [DllImport("St7API.dll")]
        public static extern int St7RotateModel(int uID, double RX, double RY, double RZ);
        [DllImport("St7API.dll")]
        public static extern int St7ShowEntity(int uID, int Entity);
        [DllImport("St7API.dll")]
        public static extern int St7HideEntity(int uID, int Entity);
        [DllImport("St7API.dll")]
        public static extern int St7SetEntityDisplay(int uID, int Entity, int[] Integers);
        [DllImport("St7API.dll")]
        public static extern int St7GetEntityDisplay(int uID, int Entity, int[] Integers);
        [DllImport("St7API.dll")]
        public static extern int St7ShowPointAttributes(int uID);
        [DllImport("St7API.dll")]
        public static extern int St7HidePointAttributes(int uID);
        [DllImport("St7API.dll")]
        public static extern int St7ShowEntityAttributes(int uID);
        [DllImport("St7API.dll")]
        public static extern int St7HideEntityAttributes(int uID);
        [DllImport("St7API.dll")]
        public static extern int St7PositionModelWindow(int uID, int Left, int Top, int Width, int Height);
        [DllImport("St7API.dll")]
        public static extern int St7GetModelWindowPosition(int uID, ref int Left, ref int Top, ref int Width, ref int Height);
        [DllImport("St7API.dll")]
        public static extern int St7GetDrawAreaSize(int uID, ref int Width, ref int Height);
        [DllImport("St7API.dll")]
        public static extern int St7ShowProperty(int uID, int Entity, int PropNum);
        [DllImport("St7API.dll")]
        public static extern int St7HideProperty(int uID, int Entity, int PropNum);
        [DllImport("St7API.dll")]
        public static extern int St7ShowGroup(int uID, int GroupID);
        [DllImport("St7API.dll")]
        public static extern int St7HideGroup(int uID, int GroupID);
        [DllImport("St7API.dll")]
        public static extern int St7SetBeamResultDisplay(int uID, int[] Integers);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlateResultDisplay(int uID, int[] Integers);
        [DllImport("St7API.dll")]
        public static extern int St7SetBrickResultDisplay(int uID, int[] Integers);
        [DllImport("St7API.dll")]
        public static extern int St7SetWindowResultCase(int uID, int CaseNum);
        [DllImport("St7API.dll")]
        public static extern int St7SetWindowLoadCase(int uID, int CaseNum);
        [DllImport("St7API.dll")]
        public static extern int St7SetWindowFreedomCase(int uID, int CaseNum);
        [DllImport("St7API.dll")]
        public static extern int St7SetWindowUCSCase(int uID, int CaseNum);
        [DllImport("St7API.dll")]
        public static extern int St7SetEntityContourFile(int uID, int Entity, int FileType, string FileName);
        [DllImport("St7API.dll")]
        public static extern int St7GetEntityContourFile(int uID, int Entity, ref int FileType, StringBuilder FileName, int MaxStringLen);
        [DllImport("St7API.dll")]
        public static extern int St7SetDisplacementScale(int uID, double DispScale, int ScaleType);
        [DllImport("St7API.dll")]
        public static extern int St7GetDisplacementScale(int uID, ref double DispScale, ref int ScaleType);
        [DllImport("St7API.dll")]
        public static extern int St7ImportST7File(int uID, string FileName, int Mode);
        [DllImport("St7API.dll")]
        public static extern int St7ImportIGESFile(int uID, string FileName, int[] Integers, double[] Doubles, int Mode);
        [DllImport("St7API.dll")]
        public static extern int St7ImportACISFile(int uID, string FileName, int[] Integers, double[] Doubles, int Mode);
        [DllImport("St7API.dll")]
        public static extern int St7ImportSTEPFile(int uID, string FileName, int[] Integers, double[] Doubles, int Mode);
        [DllImport("St7API.dll")]
        public static extern int St7ImportST6BinaryFile(int uID, string FileName, int Mode);
        [DllImport("St7API.dll")]
        public static extern int St7ImportST6TextFile(int uID, string FileName, int Mode);
        [DllImport("St7API.dll")]
        public static extern int St7ImportDXFFile(int uID, string FileName, int[] Integers, int Mode);
        [DllImport("St7API.dll")]
        public static extern int St7ImportSTLFile(int uID, string FileName, int Mode);
        [DllImport("St7API.dll")]
        public static extern int St7ImportNASTRANFile(int uID, string FileName, int[] Integers, int Mode);
        [DllImport("St7API.dll")]
        public static extern int St7ImportANSYSFile(int uID, string FileName, string LoadCaseFilePath, int[] Integers, int Mode);
        [DllImport("St7API.dll")]
        public static extern int St7ImportSTAADFile(int uID, string FileName, int[] Integers, int Mode);
        [DllImport("St7API.dll")]
        public static extern int St7ImportSAP2000File(int uID, string FileName, int[] Integers, int Mode);
        [DllImport("St7API.dll")]
        public static extern int St7ExportImageFile(int uID, string FileName, int ImageType, int Width, int Height);
        [DllImport("St7API.dll")]
        public static extern int St7ExportST7File(int uID, string FileName, int Mode, int ExportFormat);
        [DllImport("St7API.dll")]
        public static extern int St7ExportIGESFile(int uID, string FileName, int[] Integers, int Mode);
        [DllImport("St7API.dll")]
        public static extern int St7ExportSTEPFile(int uID, string FileName, int[] Integers, int Mode);
        [DllImport("St7API.dll")]
        public static extern int St7ExportDXFFile(int uID, string FileName, int[] Integers, int Mode);
        [DllImport("St7API.dll")]
        public static extern int St7ExportNASTRANFile(int uID, string FileName, int[] Integers, double[] Doubles, int Mode);
        [DllImport("St7API.dll")]
        public static extern int St7ExportANSYSFile(int uID, string FileName, int[] Integers, int Mode);
        [DllImport("St7API.dll")]
        public static extern int St7PlayAnimationFile(int pHandle, string FileName, ref int aHandle);
        [DllImport("St7API.dll")]
        public static extern int St7CreateAnimation(int uID, int[] Integers, ref int aHandle);
        [DllImport("St7API.dll")]
        public static extern int St7CreateAnimationFile(int uID, int[] Integers, string FileName);
        [DllImport("St7API.dll")]
        public static extern int St7CloseAnimation(int aHandle);
        [DllImport("St7API.dll")]
        public static extern int St7SetAnimationCase(int uID, int CaseNum, byte Activate);
        [DllImport("St7API.dll")]
        public static extern int St7GetAnimationCase(int uID, int CaseNum, ref byte Active);
        [DllImport("St7API.dll")]
        public static extern int St7GetTotal(int uID, int Entity, ref int Total);
        [DllImport("St7API.dll")]
        public static extern int St7GetTitle(int uID, int TitleType, StringBuilder TitleString, int MaxStringLen);
        [DllImport("St7API.dll")]
        public static extern int St7SetTitle(int uID, int TitleType, string TitleString);
        [DllImport("St7API.dll")]
        public static extern int St7AddComment(int uID, string CommentString);
        [DllImport("St7API.dll")]
        public static extern int St7GetNumComments(int uID, ref int NumComments);
        [DllImport("St7API.dll")]
        public static extern int St7GetComment(int uID, int Comment, StringBuilder CommentString, int MaxStringLen);
        [DllImport("St7API.dll")]
        public static extern int St7SetComment(int uID, int Comment, string CommentString);
        [DllImport("St7API.dll")]
        public static extern int St7DeleteComment(int uID, int Comment);
        [DllImport("St7API.dll")]
        public static extern int St7GetBeamAxisSystem(int uID, int EltNum, byte Initial, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlateAxisSystem(int uID, int EltNum, byte Initial, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetBrickFaceAxisSystem(int uID, int EltNum, int FaceNum, byte Initial, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlateNumPlies(int uID, int EltNum, ref int NumPlies);
        [DllImport("St7API.dll")]
        public static extern int St7GetNumBXSLoopsAndPlates(int uID, int PropNum, ref int NumLoops, ref int NumPlates);
        [DllImport("St7API.dll")]
        public static extern int St7GetNumBXSLoopPoints(int uID, int PropNum, int LoopNum, ref int NumPoints);
        [DllImport("St7API.dll")]
        public static extern int St7GetBXSLoop(int uID, int PropNum, int LoopNum, int MaxPoints, ref int NumPoints, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GenerateBXS(int uID, string BXSName, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7NewLoadCase(int uID, string CaseName);
        [DllImport("St7API.dll")]
        public static extern int St7NewSeismicCase(int uID, string CaseName);
        [DllImport("St7API.dll")]
        public static extern int St7NewFreedomCase(int uID, string CaseName);
        [DllImport("St7API.dll")]
        public static extern int St7GetNumLoadCase(int uID, ref int NumCases);
        [DllImport("St7API.dll")]
        public static extern int St7GetNumSeismicCase(int uID, ref int NumCases);
        [DllImport("St7API.dll")]
        public static extern int St7GetNumFreedomCase(int uID, ref int NumCases);
        [DllImport("St7API.dll")]
        public static extern int St7SetLoadCaseName(int uID, int CaseNum, string CaseName);
        [DllImport("St7API.dll")]
        public static extern int St7GetLoadCaseName(int uID, int CaseNum, StringBuilder CaseName, int MaxStringLen);
        [DllImport("St7API.dll")]
        public static extern int St7SetSeismicCaseName(int uID, int CaseNum, string CaseName);
        [DllImport("St7API.dll")]
        public static extern int St7GetSeismicCaseName(int uID, int CaseNum, StringBuilder CaseName, int MaxStringLen);
        [DllImport("St7API.dll")]
        public static extern int St7SetFreedomCaseName(int uID, int CaseNum, string CaseName);
        [DllImport("St7API.dll")]
        public static extern int St7GetFreedomCaseName(int uID, int CaseNum, StringBuilder CaseName, int MaxStringLen);
        [DllImport("St7API.dll")]
        public static extern int St7SetLoadCaseDefaults(int uID, int CaseNum, double[] Defaults);
        [DllImport("St7API.dll")]
        public static extern int St7GetLoadCaseDefaults(int uID, int CaseNum, double[] Defaults);
        [DllImport("St7API.dll")]
        public static extern int St7SetSeismicCaseDefaults(int uID, int CaseNum, double[] Defaults);
        [DllImport("St7API.dll")]
        public static extern int St7GetSeismicCaseDefaults(int uID, int CaseNum, double[] Defaults);
        [DllImport("St7API.dll")]
        public static extern int St7SetFreedomCaseDefaults(int uID, int CaseNum, int[] Defaults);
        [DllImport("St7API.dll")]
        public static extern int St7GetFreedomCaseDefaults(int uID, int CaseNum, int[] Defaults);
        [DllImport("St7API.dll")]
        public static extern int St7SetLoadCaseType(int uID, int CaseNum, int CaseType);
        [DllImport("St7API.dll")]
        public static extern int St7GetLoadCaseType(int uID, int CaseNum, ref int CaseType);
        [DllImport("St7API.dll")]
        public static extern int St7SetLoadCaseGravityDir(int uID, int CaseNum, int GravDir);
        [DllImport("St7API.dll")]
        public static extern int St7GetLoadCaseGravityDir(int uID, int CaseNum, ref int GravDir);
        [DllImport("St7API.dll")]
        public static extern int St7SetFreedomCaseType(int uID, int CaseNum, int CaseType);
        [DllImport("St7API.dll")]
        public static extern int St7GetFreedomCaseType(int uID, int CaseNum, ref int CaseType);
        [DllImport("St7API.dll")]
        public static extern int St7SetLoadCaseMassOption(int uID, int CaseNum, byte SMass, byte NSMass);
        [DllImport("St7API.dll")]
        public static extern int St7GetLoadCaseMassOption(int uID, int CaseNum, ref byte SMass, ref byte NSMass);
        [DllImport("St7API.dll")]
        public static extern int St7EnableSeismicNSMassCase(int uID, int SeismicCaseNum, int LoadCaseNum);
        [DllImport("St7API.dll")]
        public static extern int St7DisableSeismicNSMassCase(int uID, int SeismicCaseNum, int LoadCaseNum);
        [DllImport("St7API.dll")]
        public static extern int St7GetSeismicNSMassCaseState(int uID, int SeismicCaseNum, int LoadCaseNum, ref byte State);
        [DllImport("St7API.dll")]
        public static extern int St7DeleteLoadCase(int uID, int CaseNum);
        [DllImport("St7API.dll")]
        public static extern int St7DeleteSeismicCase(int uID, int CaseNum);
        [DllImport("St7API.dll")]
        public static extern int St7DeleteFreedomCase(int uID, int CaseNum);
        [DllImport("St7API.dll")]
        public static extern int St7SetUCS(int uID, int UCSId, int UCSType, double[] UCSDoubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetUCS(int uID, int UCSId, ref int UCSType, double[] UCSDoubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetUCSName(int uID, int UCSId, string UCSName);
        [DllImport("St7API.dll")]
        public static extern int St7GetUCSName(int uID, int UCSId, StringBuilder UCSName, int MaxStringLen);
        [DllImport("St7API.dll")]
        public static extern int St7GetUCSID(int uID, int Index, ref int UCSId);
        [DllImport("St7API.dll")]
        public static extern int St7GetNumUCS(int uID, ref int NumUCS);
        [DllImport("St7API.dll")]
        public static extern int St7GetGroupIDName(int uID, int ID, StringBuilder GName, int MaxStringLen);
        [DllImport("St7API.dll")]
        public static extern int St7GetNumGroups(int uID, ref int NumGroups);
        [DllImport("St7API.dll")]
        public static extern int St7GetGroupByIndex(int uID, int Index, StringBuilder GName, int MaxStringLen, ref int GroupID);
        [DllImport("St7API.dll")]
        public static extern int St7NewChildGroup(int uID, int ParentID, string GName, ref int ChildID);
        [DllImport("St7API.dll")]
        public static extern int St7GetGroupParent(int uID, int GroupID, ref int ParentID);
        [DllImport("St7API.dll")]
        public static extern int St7GetGroupChild(int uID, int GroupID, ref int ChildID);
        [DllImport("St7API.dll")]
        public static extern int St7GetGroupSibling(int uID, int GroupID, ref int SiblingID);
        [DllImport("St7API.dll")]
        public static extern int St7DeleteGroup(int uID, int GroupID);
        [DllImport("St7API.dll")]
        public static extern int St7SetGroupColour(int uID, int GroupID, int GroupCol);
        [DllImport("St7API.dll")]
        public static extern int St7GetGroupColour(int uID, int GroupID, ref int GroupCol);
        [DllImport("St7API.dll")]
        public static extern int St7AddStage(int uID, string StageName, int[] Integers);
        [DllImport("St7API.dll")]
        public static extern int St7InsertStage(int uID, int Stage, string StageName, int[] Integers);
        [DllImport("St7API.dll")]
        public static extern int St7DeleteStage(int uID, int Stage);
        [DllImport("St7API.dll")]
        public static extern int St7GetNumStages(int uID, ref int NumStages);
        [DllImport("St7API.dll")]
        public static extern int St7GetStageName(int uID, int Stage, StringBuilder StageName, int MaxStringLen);
        [DllImport("St7API.dll")]
        public static extern int St7SetStageName(int uID, int Stage, string StageName);
        [DllImport("St7API.dll")]
        public static extern int St7GetStageData(int uID, int Stage, int[] Integers);
        [DllImport("St7API.dll")]
        public static extern int St7SetStageData(int uID, int Stage, int[] Integers);
        [DllImport("St7API.dll")]
        public static extern int St7EnableStageGroup(int uID, int Stage, int GroupID);
        [DllImport("St7API.dll")]
        public static extern int St7DisableStageGroup(int uID, int Stage, int GroupID);
        [DllImport("St7API.dll")]
        public static extern int St7GetStageGroupState(int uID, int Stage, int GroupID, ref byte State);
        [DllImport("St7API.dll")]
        public static extern int St7GetUnits(int uID, int[] Units);
        [DllImport("St7API.dll")]
        public static extern int St7SetUnits(int uID, int[] Units);
        [DllImport("St7API.dll")]
        public static extern int St7GetRCUnits(int uID, ref int AreaUnit, ref int LengthUnit);
        [DllImport("St7API.dll")]
        public static extern int St7SetRCUnits(int uID, int AreaUnit, int LengthUnit);
        [DllImport("St7API.dll")]
        public static extern int St7ConvertUnits(int uID, int[] Units);
        [DllImport("St7API.dll")]
        public static extern int St7SetNodeXYZ(int uID, int NodeNum, double[] XYZ);
        [DllImport("St7API.dll")]
        public static extern int St7GetNodeXYZ(int uID, int NodeNum, double[] XYZ);
        [DllImport("St7API.dll")]
        public static extern int St7GetNodeUCS(int uID, int NodeNum, int UCSId, double[] XYZ);
        [DllImport("St7API.dll")]
        public static extern int St7SetNodeUCS(int uID, int NodeNum, int UCSId, double[] XYZ);
        [DllImport("St7API.dll")]
        public static extern int St7SetElementConnection(int uID, int Entity, int EltNum, int PropNum, int[] Connection);
        [DllImport("St7API.dll")]
        public static extern int St7GetElementConnection(int uID, int Entity, int EltNum, int[] Connection);
        [DllImport("St7API.dll")]
        public static extern int St7GetElementData(int uID, int Entity, int EltNum, ref double EltData);
        [DllImport("St7API.dll")]
        public static extern int St7GetElementCentroid(int uID, int Entity, int EltNum, int FaceEdgeNum, double[] XYZ);
        [DllImport("St7API.dll")]
        public static extern int St7SetMasterSlaveLink(int uID, int LinkNum, int UCSId, int[] Connection, int[] Integers);
        [DllImport("St7API.dll")]
        public static extern int St7GetMasterSlaveLink(int uID, int LinkNum, ref int UCSId, int[] Connection, int[] Integers);
        [DllImport("St7API.dll")]
        public static extern int St7SetSectorSymmetryLink(int uID, int LinkNum, int Axis, int[] Connection);
        [DllImport("St7API.dll")]
        public static extern int St7GetSectorSymmetryLink(int uID, int LinkNum, ref int Axis, int[] Connection);
        [DllImport("St7API.dll")]
        public static extern int St7SetCouplingLink(int uID, int LinkNum, int Couple, int[] Connection);
        [DllImport("St7API.dll")]
        public static extern int St7GetCouplingLink(int uID, int LinkNum, ref int Couple, int[] Connection);
        [DllImport("St7API.dll")]
        public static extern int St7SetPinnedLink(int uID, int LinkNum, int[] Connection);
        [DllImport("St7API.dll")]
        public static extern int St7GetPinnedLink(int uID, int LinkNum, int[] Connection);
        [DllImport("St7API.dll")]
        public static extern int St7SetRigidLink(int uID, int LinkNum, int UCSId, int Plane, int[] Connection);
        [DllImport("St7API.dll")]
        public static extern int St7GetRigidLink(int uID, int LinkNum, ref int UCSId, ref int Plane, int[] Connection);
        [DllImport("St7API.dll")]
        public static extern int St7SetShrinkLink(int uID, int LinkNum, int[] Connection, int[] Integers);
        [DllImport("St7API.dll")]
        public static extern int St7GetShrinkLink(int uID, int LinkNum, int[] Connection, int[] Integers);
        [DllImport("St7API.dll")]
        public static extern int St7SetTwoPointLink(int uID, int LinkNum, int[] Connection, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetTwoPointLink(int uID, int LinkNum, int[] Connection, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetAttachmentLink(int uID, int LinkNum, int[] Connection, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetAttachmentLink(int uID, int LinkNum, int[] Connection, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetMultiPointLink(int uID, int LinkNum, int NumNodes, int FactorsType, int Couple, int[] Connection, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetNumMultiPointLinkNodes(int uID, int LinkNum, ref int NumNodes);
        [DllImport("St7API.dll")]
        public static extern int St7GetMultiPointLink(int uID, int LinkNum, ref int FactorsType, ref int Couple, int[] Connection, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetLinkType(int uID, int LinkNum, ref int LinkType);
        [DllImport("St7API.dll")]
        public static extern int St7GetVertexXYZ(int uID, int VertexNum, double[] XYZ);
        [DllImport("St7API.dll")]
        public static extern int St7GetGeometryFaceOuterLoops(int uID, int FaceNum, int[] OuterLoops);
        [DllImport("St7API.dll")]
        public static extern int St7GetNumGeometryFaceCavityLoops(int uID, int FaceNum, ref int NumCavityLoops);
        [DllImport("St7API.dll")]
        public static extern int St7GetGeometryFaceCavityLoops(int uID, int FaceNum, int MaxCavityLoops, int[] Integers);
        [DllImport("St7API.dll")]
        public static extern int St7GetNumGeometryFaceEdges(int uID, int FaceNum, ref int NumEdges);
        [DllImport("St7API.dll")]
        public static extern int St7GetGeometryFaceEdges(int uID, int FaceNum, int MaxEdges, int[] Integers);
        [DllImport("St7API.dll")]
        public static extern int St7GetGeometryEdgeLength(int uID, int EdgeNum, ref double EdgeLength);
        [DllImport("St7API.dll")]
        public static extern int St7GetNumGeometryFaceVertices(int uID, int FaceNum, ref int NumVertices);
        [DllImport("St7API.dll")]
        public static extern int St7GetGeometryFaceVertices(int uID, int FaceNum, int MaxVertices, int[] Integers);
        [DllImport("St7API.dll")]
        public static extern int St7GetGeometryEdgeVertices(int uID, int EdgeNum, int[] EdgeVertices);
        [DllImport("St7API.dll")]
        public static extern int St7GetGeometryFaceSurface(int uID, int FaceNum, ref int SurfaceNum);
        [DllImport("St7API.dll")]
        public static extern int St7GetGeometrySurfaceType(int uID, int SurfaceNum, ref int SurfaceType);
        [DllImport("St7API.dll")]
        public static extern int St7InvalidateGeometryFace(int uID, int FaceNum);
        [DllImport("St7API.dll")]
        public static extern int St7InvalidateGeometryFaceCavityLoopID(int uID, int FaceNum, int LoopNum);
        [DllImport("St7API.dll")]
        public static extern int St7InvalidateGeometryFaceCavityLoopIndex(int uID, int FaceNum, int LoopIndex);
        [DllImport("St7API.dll")]
        public static extern int St7DeleteInvalidGeometryFaces(int uID, ref int NumFacesDeleted, ref int NumCavityLoopsDeleted);
        [DllImport("St7API.dll")]
        public static extern int St7GetCleanGeometryData(int uID, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetCleanGeometryData(int uID, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7CleanGeometry(int uID, ref int ChangesMade, int Mode);
        [DllImport("St7API.dll")]
        public static extern int St7GetGeometrySize(int uID, ref double Size);
        [DllImport("St7API.dll")]
        public static extern int St7SurfaceMesh(int uID, int[] Integers, double[] Doubles, int Mode);
        [DllImport("St7API.dll")]
        public static extern int St7SolidTetMesh(int uID, int[] Integers, int Mode);
        [DllImport("St7API.dll")]
        public static extern int St7MeshFromLoops(int uID, int[] Integers, double[] Doubles, int[] Loops, double[] Points, int Mode);
        [DllImport("St7API.dll")]
        public static extern int St7SetLoadPath(int uID, int LoadPathID, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetLoadPath(int uID, int LoadPathID, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7DeleteLoadPath(int uID, int LoadPathID);
        [DllImport("St7API.dll")]
        public static extern int St7SetNodeID(int uID, int NodeNum, int NodeID);
        [DllImport("St7API.dll")]
        public static extern int St7SetNodeRestraint6(int uID, int NodeNum, int CaseNum, int UCSId, int[] Status, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetNodeForce3(int uID, int NodeNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetNodeMoment3(int uID, int NodeNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetNodeTemperature1(int uID, int NodeNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetNodeTemperatureType1(int uID, int NodeNum, int CaseNum, int tType);
        [DllImport("St7API.dll")]
        public static extern int St7SetNodeTemperatureTable(int uID, int NodeNum, int CaseNum, int TableID);
        [DllImport("St7API.dll")]
        public static extern int St7SetNodeKTranslation3F(int uID, int NodeNum, int CaseNum, int UCSId, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetNodeKRotation3F(int uID, int NodeNum, int CaseNum, int UCSId, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetNodeTMass3(int uID, int NodeNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetNodeRMass3(int uID, int NodeNum, int UCSId, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetNodeNSMass5(int uID, int NodeNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetNodeKDamping3F(int uID, int NodeNum, int CaseNum, int UCSId, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetNodeHeatSource1(int uID, int NodeNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetNodeHeatSourceTables(int uID, int NodeNum, int CaseNum, int[] Tables);
        [DllImport("St7API.dll")]
        public static extern int St7SetNodeInitialVelocity3(int uID, int NodeNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetNodeAcceleration3(int uID, int NodeNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetNodeResponse(int uID, int NodeNum, int CaseNum, int ResponseType, int UCSId, int[] Status);
        [DllImport("St7API.dll")]
        public static extern int St7GetNodeID(int uID, int NodeNum, ref int NodeID);
        [DllImport("St7API.dll")]
        public static extern int St7GetNodeRestraint6(int uID, int NodeNum, int CaseNum, ref int UCSId, int[] Status, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetNodeForce3(int uID, int NodeNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetNodeMoment3(int uID, int NodeNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetNodeTemperature1(int uID, int NodeNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetNodeTemperatureType1(int uID, int NodeNum, int CaseNum, ref int tType);
        [DllImport("St7API.dll")]
        public static extern int St7GetNodeTemperatureTable(int uID, int NodeNum, int CaseNum, ref int TableID);
        [DllImport("St7API.dll")]
        public static extern int St7GetNodeTMass3(int uID, int NodeNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetNodeRMass3(int uID, int NodeNum, ref int UCSId, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetNodeKTranslation3F(int uID, int NodeNum, int CaseNum, ref int UCSId, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetNodeKRotation3F(int uID, int NodeNum, int CaseNum, ref int UCSId, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetNodeNSMass5(int uID, int NodeNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetNodeKDamping3F(int uID, int NodeNum, int CaseNum, ref int UCSId, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetNodeHeatSource1(int uID, int NodeNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetNodeHeatSourceTables(int uID, int NodeNum, int CaseNum, int[] Tables);
        [DllImport("St7API.dll")]
        public static extern int St7GetNodeInitialVelocity3(int uID, int NodeNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetNodeAcceleration3(int uID, int NodeNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetNodeResponse(int uID, int NodeNum, int CaseNum, ref int ResponseType, ref int UCSId, int[] Status);
        [DllImport("St7API.dll")]
        public static extern int St7SetBeamID(int uID, int BeamNum, int BeamID);
        [DllImport("St7API.dll")]
        public static extern int St7SetBeamReferenceAngle1(int uID, int BeamNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetBeamConnectionUCS(int uID, int BeamNum, int BeamEnd, int UCSId);
        [DllImport("St7API.dll")]
        public static extern int St7SetBeamTaper2(int uID, int BeamNum, int TaperAxis, int TaperType, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetBeamOffset2(int uID, int BeamNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetBeamSupport2F(int uID, int BeamNum, int CaseNum, int Status, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetBeamSectionFactor7(int uID, int BeamNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetBeamTRelease3(int uID, int BeamNum, int BeamEnd, int[] Status, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetBeamRRelease3(int uID, int BeamNum, int BeamEnd, int[] Status, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetBeamCableFreeLength1(int uID, int BeamNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetBeamRadius1(int uID, int BeamNum, int BeamDir, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetPipePressure2AF(int uID, int BeamNum, int CaseNum, int Status, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetPipeTemperature2OT(int uID, int BeamNum, int CaseNum, int Status, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetBeamStringGroup1(int uID, int BeamNum, int StringID);
        [DllImport("St7API.dll")]
        public static extern int St7SetBeamPreLoad1(int uID, int BeamNum, int CaseNum, int LoadType, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetBeamTempGradient2(int uID, int BeamNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetBeamCFL4ID(int uID, int BeamNum, int CaseNum, int ID, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetBeamCFG4ID(int uID, int BeamNum, int CaseNum, int ID, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetBeamCML4ID(int uID, int BeamNum, int CaseNum, int ID, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetBeamCMG4ID(int uID, int BeamNum, int CaseNum, int ID, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetBeamDLL6ID(int uID, int BeamNum, int BeamDir, int CaseNum, int DLType, int ID, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetBeamDML6ID(int uID, int BeamNum, int BeamDir, int CaseNum, int DLType, int ID, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetBeamDLG6ID(int uID, int BeamNum, int BeamDir, int ProjectFlag, int CaseNum, int DLType, int ID, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetBeamNSMass10ID(int uID, int BeamNum, int CaseNum, int DLType, int ID, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetBeamConvection2(int uID, int BeamNum, int BeamEnd, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetBeamConvectionTables(int uID, int BeamNum, int BeamEnd, int CaseNum, int[] Tables);
        [DllImport("St7API.dll")]
        public static extern int St7SetBeamRadiation2(int uID, int BeamNum, int BeamEnd, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetBeamRadiationTables(int uID, int BeamNum, int BeamEnd, int CaseNum, int[] Tables);
        [DllImport("St7API.dll")]
        public static extern int St7SetBeamFlux1(int uID, int BeamNum, int BeamEnd, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetBeamFluxTables(int uID, int BeamNum, int BeamEnd, int CaseNum, int[] Tables);
        [DllImport("St7API.dll")]
        public static extern int St7SetBeamHeatSource1(int uID, int BeamNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetBeamHeatSourceTables(int uID, int BeamNum, int CaseNum, int[] Tables);
        [DllImport("St7API.dll")]
        public static extern int St7SetBeamResponse(int uID, int BeamNum, int BeamEnd, int CaseNum, int[] Status);
        [DllImport("St7API.dll")]
        public static extern int St7SetBeamCreepLoadingAge1(int uID, int BeamNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetBeamEndAttachment1(int uID, int BeamNum, int BeamEnd, int AttachType, int ConnectType, int PropNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetBeamID(int uID, int BeamNum, ref int BeamID);
        [DllImport("St7API.dll")]
        public static extern int St7GetBeamReferenceAngle1(int uID, int BeamNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetBeamConnectionUCS(int uID, int BeamNum, int BeamEnd, ref int UCSId);
        [DllImport("St7API.dll")]
        public static extern int St7GetBeamTaper2(int uID, int BeamNum, int TaperAxis, ref int TaperType, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetBeamOffset2(int uID, int BeamNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetBeamSupport2F(int uID, int BeamNum, int CaseNum, ref int Status, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetBeamSectionFactor7(int uID, int BeamNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetBeamTRelease3(int uID, int BeamNum, int BeamEnd, int[] Status, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetBeamRRelease3(int uID, int BeamNum, int BeamEnd, int[] Status, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetBeamCableFreeLength1(int uID, int BeamNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetBeamRadius1(int uID, int BeamNum, ref int BeamDir, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetPipePressure2AF(int uID, int BeamNum, int CaseNum, ref int Status, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetPipeTemperature2OT(int uID, int BeamNum, int CaseNum, ref int Status, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetBeamStringGroup1(int uID, int BeamNum, ref int StringID);
        [DllImport("St7API.dll")]
        public static extern int St7GetBeamPreLoad1(int uID, int BeamNum, int CaseNum, ref int LoadType, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetBeamTempGradient2(int uID, int BeamNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetBeamCFL4ID(int uID, int BeamNum, int CaseNum, int ID, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetBeamCFG4ID(int uID, int BeamNum, int CaseNum, int ID, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetBeamCML4ID(int uID, int BeamNum, int CaseNum, int ID, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetBeamCMG4ID(int uID, int BeamNum, int CaseNum, int ID, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetBeamDLL6ID(int uID, int BeamNum, int BeamDir, int CaseNum, int ID, ref int DLType, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetBeamDML6ID(int uID, int BeamNum, int BeamDir, int CaseNum, int ID, ref int DLType, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetBeamDLG6ID(int uID, int BeamNum, int BeamDir, int CaseNum, int ID, ref int ProjectFlag, ref int DLType, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetBeamNSMass10ID(int uID, int BeamNum, int CaseNum, int ID, ref int DLType, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetBeamConvection2(int uID, int BeamNum, int BeamEnd, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetBeamConvectionTables(int uID, int BeamNum, int BeamEnd, int CaseNum, int[] Tables);
        [DllImport("St7API.dll")]
        public static extern int St7GetBeamRadiation2(int uID, int BeamNum, int BeamEnd, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetBeamRadiationTables(int uID, int BeamNum, int BeamEnd, int CaseNum, int[] Tables);
        [DllImport("St7API.dll")]
        public static extern int St7GetBeamFlux1(int uID, int BeamNum, int BeamEnd, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetBeamFluxTables(int uID, int BeamNum, int BeamEnd, int CaseNum, int[] Tables);
        [DllImport("St7API.dll")]
        public static extern int St7GetBeamHeatSource1(int uID, int BeamNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetBeamHeatSourceTables(int uID, int BeamNum, int CaseNum, int[] Tables);
        [DllImport("St7API.dll")]
        public static extern int St7GetBeamResponse(int uID, int BeamNum, int BeamEnd, int CaseNum, int[] Status);
        [DllImport("St7API.dll")]
        public static extern int St7GetBeamCreepLoadingAge1(int uID, int BeamNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetBeamEndAttachment1(int uID, int BeamNum, int BeamEnd, ref int AttachType, ref int ConnectType, ref int PropNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlateID(int uID, int PlateNum, int PlateID);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlateXAngle1(int uID, int PlateNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlateThickness2(int uID, int PlateNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlateOffset1(int uID, int PlateNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlateEdgeSupport1F(int uID, int PlateNum, int CaseNum, int EdgeNum, int Status, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlateFaceSupport1F(int uID, int PlateNum, int CaseNum, int Status, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlateEdgeRelease1(int uID, int PlateNum, int EdgeNum, int[] Status);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlatePreLoad3(int uID, int PlateNum, int CaseNum, int LoadType, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlateTempGradient1(int uID, int PlateNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlatePointForce6(int uID, int PlateNum, int CaseNum, int Position, int ID, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlatePointMoment6(int uID, int PlateNum, int CaseNum, int Position, int ID, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlateEdgePressure1(int uID, int PlateNum, int CaseNum, int EdgeNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlateEdgeShear1(int uID, int PlateNum, int CaseNum, int EdgeNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlateEdgeNormalShear1(int uID, int PlateNum, int CaseNum, int EdgeNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlateNormalPressure1(int uID, int PlateNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlateGlobalPressure3(int uID, int PlateNum, int ProjectFlag, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlateShear2(int uID, int PlateNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlateNSMass5(int uID, int PlateNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlateEdgeConvection2(int uID, int PlateNum, int CaseNum, int EdgeNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlateEdgeConvectionTables(int uID, int PlateNum, int CaseNum, int EdgeNum, int[] Tables);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlateEdgeRadiation2(int uID, int PlateNum, int CaseNum, int EdgeNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlateEdgeRadiationTables(int uID, int PlateNum, int CaseNum, int EdgeNum, int[] Tables);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlateFlux1(int uID, int PlateNum, int CaseNum, int EdgeNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlateFluxTables(int uID, int PlateNum, int CaseNum, int EdgeNum, int[] Tables);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlateFaceConvection2(int uID, int PlateNum, int CaseNum, int Surface, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlateFaceConvectionTables(int uID, int PlateNum, int CaseNum, int Surface, int[] Tables);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlateFaceRadiation2(int uID, int PlateNum, int CaseNum, int Surface, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlateFaceRadiationTables(int uID, int PlateNum, int CaseNum, int Surface, int[] Tables);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlateHeatSource1(int uID, int PlateNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlateHeatSourceTables(int uID, int PlateNum, int CaseNum, int[] Tables);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlateSoilStress2(int uID, int PlateNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlateSoilRatio2(int uID, int PlateNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlateResponse(int uID, int PlateNum, int CaseNum, int ResponseType, int UCSId, int[] Status);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlateLoadPatch4(int uID, int PlateNum, int PatchType, int EdgeBits, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlateReinforcement2(int uID, int PlateNum, int LayoutID, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlateCreepLoadingAge1(int uID, int PlateNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlateEdgeAttachment1(int uID, int PlateNum, int EdgeNum, int Direction, int AttachType, int ConnectType, int PropNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlateFaceAttachment1(int uID, int PlateNum, int Surface, int AttachType, int ConnectType, int PropNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlateID(int uID, int PlateNum, ref int PlateID);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlateXAngle1(int uID, int PlateNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlateThickness2(int uID, int PlateNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlateOffset1(int uID, int PlateNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlateEdgeSupport1F(int uID, int PlateNum, int CaseNum, int EdgeNum, ref int Status, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlateFaceSupport1F(int uID, int PlateNum, int CaseNum, ref int Status, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlateEdgeRelease1(int uID, int PlateNum, int EdgeNum, int[] Status);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlatePreLoad3(int uID, int PlateNum, int CaseNum, ref int LoadType, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlateTempGradient1(int uID, int PlateNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlatePointForce6(int uID, int PlateNum, int CaseNum, int Position, int ID, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlatePointMoment6(int uID, int PlateNum, int CaseNum, int Position, int ID, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlateEdgePressure1(int uID, int PlateNum, int CaseNum, int EdgeNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlateEdgeShear1(int uID, int PlateNum, int CaseNum, int EdgeNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlateEdgeNormalShear1(int uID, int PlateNum, int CaseNum, int EdgeNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlateNormalPressure1(int uID, int PlateNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlateGlobalPressure3(int uID, int PlateNum, int CaseNum, ref int ProjectFlag, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlateShear2(int uID, int PlateNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlateNSMass5(int uID, int PlateNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlateEdgeConvection2(int uID, int PlateNum, int CaseNum, int EdgeNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlateEdgeConvectionTables(int uID, int PlateNum, int CaseNum, int EdgeNum, int[] Tables);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlateEdgeRadiation2(int uID, int PlateNum, int CaseNum, int EdgeNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlateEdgeRadiationTables(int uID, int PlateNum, int CaseNum, int EdgeNum, int[] Tables);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlateFlux1(int uID, int PlateNum, int CaseNum, int EdgeNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlateFluxTables(int uID, int PlateNum, int CaseNum, int EdgeNum, int[] Tables);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlateFaceConvection2(int uID, int PlateNum, int CaseNum, int Surface, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlateFaceConvectionTables(int uID, int PlateNum, int CaseNum, int Surface, int[] Tables);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlateFaceRadiation2(int uID, int PlateNum, int CaseNum, int Surface, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlateFaceRadiationTables(int uID, int PlateNum, int CaseNum, int Surface, int[] Tables);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlateHeatSource1(int uID, int PlateNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlateHeatSourceTables(int uID, int PlateNum, int CaseNum, int[] Tables);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlateSoilStress2(int uID, int PlateNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlateSoilRatio2(int uID, int PlateNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlateResponse(int uID, int PlateNum, int CaseNum, ref int ResponseType, ref int UCSId, int[] Status);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlateLoadPatch4(int uID, int PlateNum, ref int PatchType, ref int EdgeBits, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlateReinforcement2(int uID, int PlateNum, ref int LayoutID, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlateCreepLoadingAge1(int uID, int PlateNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlateEdgeAttachment1(int uID, int PlateNum, int EdgeNum, ref int Direction, ref int AttachType, ref int ConnectType, ref int PropNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlateFaceAttachment1(int uID, int PlateNum, int Surface, ref int AttachType, ref int ConnectType, ref int PropNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetBrickID(int uID, int BrickNum, int BrickID);
        [DllImport("St7API.dll")]
        public static extern int St7SetBrickLocalAxes1(int uID, int BrickNum, int UCSId);
        [DllImport("St7API.dll")]
        public static extern int St7SetBrickSupport1F(int uID, int BrickNum, int FaceNum, int CaseNum, int Status, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetBrickPreLoad3(int uID, int BrickNum, int CaseNum, int LoadType, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetBrickPointForce6(int uID, int BrickNum, int FaceNum, int CaseNum, int Position, int ID, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetBrickNormalPressure1(int uID, int BrickNum, int FaceNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetBrickGlobalPressure3(int uID, int BrickNum, int FaceNum, int ProjectFlag, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetBrickShear2(int uID, int BrickNum, int FaceNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetBrickNSMass5(int uID, int BrickNum, int FaceNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetBrickConvection2(int uID, int BrickNum, int FaceNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetBrickConvectionTables(int uID, int BrickNum, int FaceNum, int CaseNum, int[] Tables);
        [DllImport("St7API.dll")]
        public static extern int St7SetBrickRadiation2(int uID, int BrickNum, int FaceNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetBrickRadiationTables(int uID, int BrickNum, int FaceNum, int CaseNum, int[] Tables);
        [DllImport("St7API.dll")]
        public static extern int St7SetBrickFlux1(int uID, int BrickNum, int FaceNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetBrickFluxTables(int uID, int BrickNum, int FaceNum, int CaseNum, int[] Tables);
        [DllImport("St7API.dll")]
        public static extern int St7SetBrickHeatSource1(int uID, int BrickNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetBrickHeatSourceTables(int uID, int BrickNum, int CaseNum, int[] Tables);
        [DllImport("St7API.dll")]
        public static extern int St7SetBrickSoilStress2(int uID, int BrickNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetBrickSoilRatio2(int uID, int BrickNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetBrickResponse(int uID, int BrickNum, int CaseNum, int UCSId, int[] Status);
        [DllImport("St7API.dll")]
        public static extern int St7SetBrickCreepLoadingAge1(int uID, int BrickNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetBrickFaceAttachment1(int uID, int BrickNum, int FaceNum, int AttachType, int ConnectType, int PropNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetBrickID(int uID, int BrickNum, ref int BrickID);
        [DllImport("St7API.dll")]
        public static extern int St7GetBrickLocalAxes1(int uID, int BrickNum, ref int UCSId);
        [DllImport("St7API.dll")]
        public static extern int St7GetBrickSupport1F(int uID, int BrickNum, int FaceNum, int CaseNum, ref int Status, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetBrickPreLoad3(int uID, int BrickNum, int CaseNum, ref int LoadType, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetBrickPointForce6(int uID, int BrickNum, int FaceNum, int CaseNum, int Position, int ID, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetBrickNormalPressure1(int uID, int BrickNum, int FaceNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetBrickGlobalPressure3(int uID, int BrickNum, int FaceNum, int CaseNum, ref int ProjectFlag, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetBrickShear2(int uID, int BrickNum, int FaceNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetBrickNSMass5(int uID, int BrickNum, int FaceNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetBrickConvection2(int uID, int BrickNum, int FaceNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetBrickConvectionTables(int uID, int BrickNum, int FaceNum, int CaseNum, int[] Tables);
        [DllImport("St7API.dll")]
        public static extern int St7GetBrickRadiation2(int uID, int BrickNum, int FaceNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetBrickRadiationTables(int uID, int BrickNum, int FaceNum, int CaseNum, int[] Tables);
        [DllImport("St7API.dll")]
        public static extern int St7GetBrickFlux1(int uID, int BrickNum, int FaceNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetBrickFluxTables(int uID, int BrickNum, int FaceNum, int CaseNum, int[] Tables);
        [DllImport("St7API.dll")]
        public static extern int St7GetBrickHeatSource1(int uID, int BrickNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetBrickHeatSourceTables(int uID, int BrickNum, int CaseNum, int[] Tables);
        [DllImport("St7API.dll")]
        public static extern int St7GetBrickSoilStress2(int uID, int BrickNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetBrickSoilRatio2(int uID, int BrickNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetBrickResponse(int uID, int BrickNum, int CaseNum, ref int UCSId, int[] Status);
        [DllImport("St7API.dll")]
        public static extern int St7GetBrickCreepLoadingAge1(int uID, int BrickNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetBrickFaceAttachment1(int uID, int BrickNum, int FaceNum, ref int AttachType, ref int ConnectType, ref int PropNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetVertexType(int uID, int VertexNum, int VertexType);
        [DllImport("St7API.dll")]
        public static extern int St7SetVertexID(int uID, int VertexNum, int VertexID);
        [DllImport("St7API.dll")]
        public static extern int St7SetVertexMeshSize1(int uID, int VertexNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetVertexRestraint6(int uID, int VertexNum, int CaseNum, int UCSId, int[] Status, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetVertexForce3(int uID, int VertexNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetVertexMoment3(int uID, int VertexNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetVertexTemperature1(int uID, int VertexNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetVertexTemperatureType1(int uID, int VertexNum, int CaseNum, int tType);
        [DllImport("St7API.dll")]
        public static extern int St7SetVertexTemperatureTable(int uID, int VertexNum, int CaseNum, int TableID);
        [DllImport("St7API.dll")]
        public static extern int St7SetVertexKTranslation3F(int uID, int VertexNum, int CaseNum, int UCSId, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetVertexKRotation3F(int uID, int VertexNum, int CaseNum, int UCSId, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetVertexTMass3(int uID, int VertexNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetVertexRMass3(int uID, int VertexNum, int UCSId, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetVertexNSMass5(int uID, int VertexNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetVertexKDamping3F(int uID, int VertexNum, int CaseNum, int UCSId, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetVertexHeatSource1(int uID, int VertexNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetVertexHeatSourceTables(int uID, int VertexNum, int CaseNum, int[] Tables);
        [DllImport("St7API.dll")]
        public static extern int St7GetVertexType(int uID, int VertexNum, ref int VertexType);
        [DllImport("St7API.dll")]
        public static extern int St7GetVertexID(int uID, int VertexNum, ref int VertexID);
        [DllImport("St7API.dll")]
        public static extern int St7GetVertexMeshSize1(int uID, int VertexNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetVertexRestraint6(int uID, int VertexNum, int CaseNum, ref int UCSId, int[] Status, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetVertexForce3(int uID, int VertexNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetVertexMoment3(int uID, int VertexNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetVertexTemperature1(int uID, int VertexNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetVertexTemperatureType1(int uID, int VertexNum, int CaseNum, ref int tType);
        [DllImport("St7API.dll")]
        public static extern int St7GetVertexTemperatureTable(int uID, int VertexNum, int CaseNum, ref int TableID);
        [DllImport("St7API.dll")]
        public static extern int St7GetVertexKTranslation3F(int uID, int VertexNum, int CaseNum, ref int UCSId, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetVertexKRotation3F(int uID, int VertexNum, int CaseNum, ref int UCSId, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetVertexTMass3(int uID, int VertexNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetVertexRMass3(int uID, int VertexNum, ref int UCSId, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetVertexNSMass5(int uID, int VertexNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetVertexKDamping3F(int uID, int VertexNum, int CaseNum, ref int UCSId, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetVertexHeatSource1(int uID, int VertexNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetVertexHeatSourceTables(int uID, int VertexNum, int CaseNum, int[] Tables);
        [DllImport("St7API.dll")]
        public static extern int St7SetGeometryEdgeType(int uID, int EdgeNum, int EdgeType);
        [DllImport("St7API.dll")]
        public static extern int St7SetGeometryEdgeRelease1(int uID, int EdgeNum, int[] Status);
        [DllImport("St7API.dll")]
        public static extern int St7SetGeometryEdgeSupport1F(int uID, int EdgeNum, int CaseNum, int Status, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetGeometryEdgePressure1(int uID, int EdgeNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetGeometryEdgeShear1(int uID, int EdgeNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetGeometryEdgeNormalShear1(int uID, int EdgeNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetGeometryEdgeConvection2(int uID, int EdgeNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetGeometryEdgeConvectionTables(int uID, int EdgeNum, int CaseNum, int[] Tables);
        [DllImport("St7API.dll")]
        public static extern int St7SetGeometryEdgeRadiation2(int uID, int EdgeNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetGeometryEdgeRadiationTables(int uID, int EdgeNum, int CaseNum, int[] Tables);
        [DllImport("St7API.dll")]
        public static extern int St7SetGeometryEdgeFlux1(int uID, int EdgeNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetGeometryEdgeFluxTables(int uID, int EdgeNum, int CaseNum, int[] Tables);
        [DllImport("St7API.dll")]
        public static extern int St7SetGeometryEdgeAttachment1(int uID, int EdgeNum, int Direction, int AttachType, int ConnectType, int PropNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetGeometryEdgeType(int uID, int EdgeNum, ref int EdgeType);
        [DllImport("St7API.dll")]
        public static extern int St7GetGeometryEdgeRelease1(int uID, int EdgeNum, int[] Status);
        [DllImport("St7API.dll")]
        public static extern int St7GetGeometryEdgeSupport1F(int uID, int EdgeNum, int CaseNum, ref int Status, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetGeometryEdgePressure1(int uID, int EdgeNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetGeometryEdgeShear1(int uID, int EdgeNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetGeometryEdgeNormalShear1(int uID, int EdgeNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetGeometryEdgeConvection2(int uID, int EdgeNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetGeometryEdgeConvectionTables(int uID, int EdgeNum, int CaseNum, int[] Tables);
        [DllImport("St7API.dll")]
        public static extern int St7GetGeometryEdgeRadiation2(int uID, int EdgeNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetGeometryEdgeRadiationTables(int uID, int EdgeNum, int CaseNum, int[] Tables);
        [DllImport("St7API.dll")]
        public static extern int St7GetGeometryEdgeFlux1(int uID, int EdgeNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetGeometryEdgeFluxTables(int uID, int EdgeNum, int CaseNum, int[] Tables);
        [DllImport("St7API.dll")]
        public static extern int St7GetGeometryEdgeAttachment1(int uID, int EdgeNum, ref int Direction, ref int AttachType, ref int ConnectType, ref int PropNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetGeometryFaceProperty(int uID, int FaceNum, int PropNum);
        [DllImport("St7API.dll")]
        public static extern int St7SetGeometryFaceID(int uID, int FaceNum, int FaceID);
        [DllImport("St7API.dll")]
        public static extern int St7SetGeometryFaceOffset1(int uID, int FaceNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetGeometryFaceSupport1F(int uID, int FaceNum, int CaseNum, int Status, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetGeometryFaceTempGradient1(int uID, int FaceNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetGeometryFaceNormalPressure1(int uID, int FaceNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetGeometryFaceGlobalPressure3(int uID, int FaceNum, int ProjectFlag, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetGeometryFaceNSMass5(int uID, int FaceNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetGeometryFaceConvection2(int uID, int FaceNum, int CaseNum, int Surface, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetGeometryFaceConvectionTables(int uID, int FaceNum, int CaseNum, int Surface, int[] Tables);
        [DllImport("St7API.dll")]
        public static extern int St7SetGeometryFaceRadiation2(int uID, int FaceNum, int CaseNum, int Surface, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetGeometryFaceRadiationTables(int uID, int FaceNum, int CaseNum, int Surface, int[] Tables);
        [DllImport("St7API.dll")]
        public static extern int St7SetGeometryFaceHeatSource1(int uID, int FaceNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetGeometryFaceHeatSourceTables(int uID, int FaceNum, int CaseNum, int[] Tables);
        [DllImport("St7API.dll")]
        public static extern int St7SetGeometryFaceAttachment1(int uID, int FaceNum, int Surface, int AttachType, int ConnectType, int PropNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetGeometryFaceProperty(int uID, int FaceNum, ref int PropNum);
        [DllImport("St7API.dll")]
        public static extern int St7GetGeometryFaceID(int uID, int FaceNum, ref int FaceID);
        [DllImport("St7API.dll")]
        public static extern int St7GetGeometryFaceOffset1(int uID, int FaceNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetGeometryFaceSupport1F(int uID, int FaceNum, int CaseNum, ref int Status, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetGeometryFaceTempGradient1(int uID, int FaceNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetGeometryFaceNormalPressure1(int uID, int FaceNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetGeometryFaceGlobalPressure3(int uID, int FaceNum, int CaseNum, ref int ProjectFlag, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetGeometryFaceNSMass5(int uID, int FaceNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetGeometryFaceConvection2(int uID, int FaceNum, int CaseNum, int Surface, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetGeometryFaceConvectionTables(int uID, int FaceNum, int CaseNum, int Surface, int[] Tables);
        [DllImport("St7API.dll")]
        public static extern int St7GetGeometryFaceRadiation2(int uID, int FaceNum, int CaseNum, int Surface, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetGeometryFaceRadiationTables(int uID, int FaceNum, int CaseNum, int Surface, int[] Tables);
        [DllImport("St7API.dll")]
        public static extern int St7GetGeometryFaceHeatSource1(int uID, int FaceNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetGeometryFaceHeatSourceTables(int uID, int FaceNum, int CaseNum, int[] Tables);
        [DllImport("St7API.dll")]
        public static extern int St7GetGeometryFaceAttachment1(int uID, int FaceNum, int Surface, ref int AttachType, ref int ConnectType, ref int PropNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetElementProperty(int uID, int Entity, int EltNum, ref int PropNum);
        [DllImport("St7API.dll")]
        public static extern int St7GetElementPropertySequence(int uID, int Entity, int EltNum, int MaxPoints, int[] Props, int[] Stages);
        [DllImport("St7API.dll")]
        public static extern int St7SetElementProperty(int uID, int Entity, int EltNum, int PropNum);
        [DllImport("St7API.dll")]
        public static extern int St7SetElementPropertySwitch(int uID, int Entity, int EltNum, int PropID, int StageID);
        [DllImport("St7API.dll")]
        public static extern int St7DeleteAttribute(int uID, int Entity, int EntityNum, int AttributeOrd, int[] Integers);
        [DllImport("St7API.dll")]
        public static extern int St7SetEntityGroup(int uID, int Entity, int EntityNum, int GroupID);
        [DllImport("St7API.dll")]
        public static extern int St7GetEntityGroup(int uID, int Entity, int EntityNum, ref int GroupID);
        [DllImport("St7API.dll")]
        public static extern int St7GetTotalProperties(int uID, int[] NumProperties, int[] LastProperty);
        [DllImport("St7API.dll")]
        public static extern int St7GetTotalCreepDefinitions(int uID, ref int NumSets, ref int LastSet);
        [DllImport("St7API.dll")]
        public static extern int St7GetTotalLaminateStacks(int uID, ref int NumStacks, ref int LastStack);
        [DllImport("St7API.dll")]
        public static extern int St7GetTotalLoadPathTemplates(int uID, ref int NumTemplates, ref int LastTemplate);
        [DllImport("St7API.dll")]
        public static extern int St7GetTotalReinforcementLayouts(int uID, ref int NumLayouts, ref int LastLayout);
        [DllImport("St7API.dll")]
        public static extern int St7GetPropertyNumByIndex(int uID, int Entity, int PropIndex, ref int PropNum);
        [DllImport("St7API.dll")]
        public static extern int St7GetCreepDefinitionNumByIndex(int uID, int Index, ref int CreepNum);
        [DllImport("St7API.dll")]
        public static extern int St7GetLaminateStackNumByIndex(int uID, int Index, ref int LaminateNum);
        [DllImport("St7API.dll")]
        public static extern int St7GetLoadPathTemplateNumByIndex(int uID, int Index, ref int PathNum);
        [DllImport("St7API.dll")]
        public static extern int St7GetReinforcementLayoutNumByIndex(int uID, int Index, ref int LayoutNum);
        [DllImport("St7API.dll")]
        public static extern int St7SetPropertyName(int uID, int Entity, int PropNum, string PropName);
        [DllImport("St7API.dll")]
        public static extern int St7GetPropertyName(int uID, int Entity, int PropNum, StringBuilder PropName, int MaxStringLen);
        [DllImport("St7API.dll")]
        public static extern int St7SetPropertyColour(int uID, int Entity, int PropNum, int PropCol);
        [DllImport("St7API.dll")]
        public static extern int St7GetPropertyColour(int uID, int Entity, int PropNum, ref int PropCol);
        [DllImport("St7API.dll")]
        public static extern int St7SetPropertyTable(int uID, int ptType, int PropNum, int TableID);
        [DllImport("St7API.dll")]
        public static extern int St7GetPropertyTable(int uID, int ptType, int PropNum, ref int TableID);
        [DllImport("St7API.dll")]
        public static extern int St7SetPropertyCreepID(int uID, int Entity, int PropNum, int CreepID);
        [DllImport("St7API.dll")]
        public static extern int St7GetPropertyCreepID(int uID, int Entity, int PropNum, ref int CreepID);
        [DllImport("St7API.dll")]
        public static extern int St7SetMaterialName(int uID, int Entity, int PropNum, string MaterialName);
        [DllImport("St7API.dll")]
        public static extern int St7GetMaterialName(int uID, int Entity, int PropNum, StringBuilder MaterialName, int MaxStringLen);
        [DllImport("St7API.dll")]
        public static extern int St7SetTimeDependentModType(int uID, int Entity, int PropNum, int ModType);
        [DllImport("St7API.dll")]
        public static extern int St7GetTimeDependentModType(int uID, int Entity, int PropNum, ref int ModType);
        [DllImport("St7API.dll")]
        public static extern int St7SetHardeningType(int uID, int Entity, int PropNum, int HardType);
        [DllImport("St7API.dll")]
        public static extern int St7GetHardeningType(int uID, int Entity, int PropNum, ref int HardType);
        [DllImport("St7API.dll")]
        public static extern int St7GetAlphaTempType(int uID, int Entity, int PropNum, ref int AlphaTempType);
        [DllImport("St7API.dll")]
        public static extern int St7SetAlphaTempType(int uID, int Entity, int PropNum, int AlphaTempType);
        [DllImport("St7API.dll")]
        public static extern int St7NewBeamProperty(int uID, int PropNum, int BeamType, string PropName);
        [DllImport("St7API.dll")]
        public static extern int St7GetBeamPropertyData(int uID, int PropNum, int[] Integers, double[] SectionData, double[] BeamMaterial);
        [DllImport("St7API.dll")]
        public static extern int St7GetBeamSectionName(int uID, int PropNum, StringBuilder SectionName, int MaxStringLen);
        [DllImport("St7API.dll")]
        public static extern int St7SetBeamSectionName(int uID, int PropNum, string SectionName);
        [DllImport("St7API.dll")]
        public static extern int St7SetBeamPropertyType(int uID, int PropNum, int BeamType);
        [DllImport("St7API.dll")]
        public static extern int St7SetBeamMirrorOption(int uID, int PropNum, int MirrorType, int CompatibleTwist, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetBeamNonlinearType(int uID, int PropNum, int NonlinType);
        [DllImport("St7API.dll")]
        public static extern int St7GetBeamNonlinearType(int uID, int PropNum, ref int NonlinType);
        [DllImport("St7API.dll")]
        public static extern int St7SetBeamSectionPropertyData(int uID, int PropNum, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetBeamSectionPropertyData(int uID, int PropNum, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetBeamSectionGeometry(int uID, int PropNum, int SectionType, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetBeamSectionGeometry(int uID, int PropNum, ref int SectionType, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetBeamSectionNominalDiscretisation(int uID, int PropNum, int[] Integers);
        [DllImport("St7API.dll")]
        public static extern int St7GetBeamSectionNominalDiscretisation(int uID, int PropNum, int[] Integers);
        [DllImport("St7API.dll")]
        public static extern int St7SetBeamSectionCircularDiscretisation(int uID, int PropNum, int[] Integers);
        [DllImport("St7API.dll")]
        public static extern int St7GetBeamSectionCircularDiscretisation(int uID, int PropNum, int[] Integers);
        [DllImport("St7API.dll")]
        public static extern int St7CalculateBeamSectionProperties(int uID, int PropNum, byte DoShear, byte ExactJ);
        [DllImport("St7API.dll")]
        public static extern int St7AssignBXS(int uID, int PropNum, string BXSName);
        [DllImport("St7API.dll")]
        public static extern int St7SetSpringDamperData(int uID, int PropNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetSpringDamperData(int uID, int PropNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetTrussData(int uID, int PropNum, int[] Integers);
        [DllImport("St7API.dll")]
        public static extern int St7GetTrussData(int uID, int PropNum, int[] Integers);
        [DllImport("St7API.dll")]
        public static extern int St7SetCableData(int uID, int PropNum, int[] Integers);
        [DllImport("St7API.dll")]
        public static extern int St7GetCableData(int uID, int PropNum, int[] Integers);
        [DllImport("St7API.dll")]
        public static extern int St7SetCutoffBarData(int uID, int PropNum, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetCutoffBarData(int uID, int PropNum, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetPointContactData(int uID, int PropNum, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetPointContactData(int uID, int PropNum, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetPipeData(int uID, int PropNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetPipeData(int uID, int PropNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetConnectionData(int uID, int PropNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetConnectionData(int uID, int PropNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetUserBeamData(int uID, int PropNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetUserBeamData(int uID, int PropNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetBeamMaterialData(int uID, int PropNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetBeamMaterialData(int uID, int PropNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetBeamUsePoisson(int uID, int PropNum);
        [DllImport("St7API.dll")]
        public static extern int St7SetBeamUseShearMod(int uID, int PropNum);
        [DllImport("St7API.dll")]
        public static extern int St7GetBeamUseMomCurv(int uID, int PropNum, ref byte UseMomCurv);
        [DllImport("St7API.dll")]
        public static extern int St7SetBeamUseMomCurv(int uID, int PropNum, byte UseMomCurv);
        [DllImport("St7API.dll")]
        public static extern int St7NewPlateProperty(int uID, int PropNum, int PlateType, int MaterialType, string PropName);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlatePropertyData(int uID, int PropNum, int[] Integers, double[] SectionData, double[] PlateMaterial);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlatePropertyType(int uID, int PropNum, int PlateType, int MaterialType);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlatePropertyType(int uID, int PropNum, ref int PlateType, ref int MaterialType);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlateNonlinearType(int uID, int PropNum, int NonlinType, int YieldType);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlateNonlinearType(int uID, int PropNum, ref int NonlinType, ref int YieldType);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlateThickness(int uID, int PropNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlateThickness(int uID, int PropNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlateLayers(int uID, int PropNum, int NumLayers);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlateLayers(int uID, int PropNum, ref int NumLayers);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlateIsotropicMaterial(int uID, int PropNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlateIsotropicMaterial(int uID, int PropNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlateOrthotropicMaterial(int uID, int PropNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlateOrthotropicMaterial(int uID, int PropNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlateRubberMaterial(int uID, int PropNum, int RubberType, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlateRubberMaterial(int uID, int PropNum, ref int RubberType, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlateAnisotropicMaterial(int uID, int PropNum, int MatType, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlateAnisotropicMaterial(int uID, int PropNum, ref int MatType, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlateUserDefinedMaterial(int uID, int PropNum, int MatType, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlateUserDefinedMaterial(int uID, int PropNum, ref int MatType, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlateMCDPMaterial(int uID, int PropNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlateMCDPMaterial(int uID, int PropNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlateSoilDCMaterial(int uID, int PropNum, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlateSoilDCMaterial(int uID, int PropNum, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlateSoilCCMaterial(int uID, int PropNum, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlateSoilCCMaterial(int uID, int PropNum, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlateSoilMCMaterial(int uID, int PropNum, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlateSoilMCMaterial(int uID, int PropNum, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlateSoilDPMaterial(int uID, int PropNum, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlateSoilDPMaterial(int uID, int PropNum, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlateSoilLSMaterial(int uID, int PropNum, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlateSoilLSMaterial(int uID, int PropNum, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlateFluidMaterial(int uID, int PropNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlateFluidMaterial(int uID, int PropNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlateUseReducedInt(int uID, int PropNum, ref byte UseReducedInt);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlateUseReducedInt(int uID, int PropNum, byte UseReducedInt);
        [DllImport("St7API.dll")]
        public static extern int St7NewBrickProperty(int uID, int PropNum, int MaterialType, string PropName);
        [DllImport("St7API.dll")]
        public static extern int St7GetBrickPropertyData(int uID, int PropNum, int[] Integers, double[] BrickMaterial);
        [DllImport("St7API.dll")]
        public static extern int St7SetBrickPropertyType(int uID, int PropNum, int MaterialType);
        [DllImport("St7API.dll")]
        public static extern int St7GetBrickPropertyType(int uID, int PropNum, ref int MaterialType);
        [DllImport("St7API.dll")]
        public static extern int St7SetBrickNonlinearType(int uID, int PropNum, int NonlinType, int YieldType);
        [DllImport("St7API.dll")]
        public static extern int St7GetBrickNonlinearType(int uID, int PropNum, ref int NonlinType, ref int YieldType);
        [DllImport("St7API.dll")]
        public static extern int St7SetBrickIsotropicMaterial(int uID, int PropNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetBrickIsotropicMaterial(int uID, int PropNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetBrickOrthotropicMaterial(int uID, int PropNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetBrickOrthotropicMaterial(int uID, int PropNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetBrickAnisotropicMaterial(int uID, int PropNum, int MatType, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetBrickAnisotropicMaterial(int uID, int PropNum, ref int MatType, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetBrickRubberMaterial(int uID, int PropNum, int RubberType, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetBrickRubberMaterial(int uID, int PropNum, ref int RubberType, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetBrickMCDPMaterial(int uID, int PropNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetBrickMCDPMaterial(int uID, int PropNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetBrickSoilDCMaterial(int uID, int PropNum, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetBrickSoilDCMaterial(int uID, int PropNum, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetBrickSoilCCMaterial(int uID, int PropNum, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetBrickSoilCCMaterial(int uID, int PropNum, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetBrickSoilMCMaterial(int uID, int PropNum, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetBrickSoilMCMaterial(int uID, int PropNum, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetBrickSoilDPMaterial(int uID, int PropNum, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetBrickSoilDPMaterial(int uID, int PropNum, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetBrickSoilLSMaterial(int uID, int PropNum, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetBrickSoilLSMaterial(int uID, int PropNum, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetBrickFluidMaterial(int uID, int PropNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetBrickFluidMaterial(int uID, int PropNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetBrickAddBubbleFunction(int uID, int PropNum, ref byte AddBubbleFunction);
        [DllImport("St7API.dll")]
        public static extern int St7SetBrickAddBubbleFunction(int uID, int PropNum, byte AddBubbleFunction);
        [DllImport("St7API.dll")]
        public static extern int St7DeleteProperty(int uID, int Entity, int PropNum);
        [DllImport("St7API.dll")]
        public static extern int St7DeleteUnusedProperties(int uID, int Entity, ref int NumDeleted);
        [DllImport("St7API.dll")]
        public static extern int St7UpdateElementPropertyData(int uID, int Entity, int PropNum);
        [DllImport("St7API.dll")]
        public static extern int St7NewPlyProperty(int uID, int PropNum, string PropName);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlyMaterial(int uID, int PropNum, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlyMaterial(int uID, int PropNum, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlateLaminateMaterial(int uID, int PropNum, ref int LamNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlateLaminateMaterial(int uID, int PropNum, int LamNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7NewLaminate(int uID, int LamNum, string LamName);
        [DllImport("St7API.dll")]
        public static extern int St7GetLaminateName(int uID, int LamNum, StringBuilder LamName, int MaxStringLen);
        [DllImport("St7API.dll")]
        public static extern int St7SetLaminateName(int uID, int LamNum, string LamName);
        [DllImport("St7API.dll")]
        public static extern int St7GetLaminateNumPlies(int uID, int LamNum, ref int NumPlies);
        [DllImport("St7API.dll")]
        public static extern int St7GetLaminatePly(int uID, int LamNum, int Pos, ref int PlyPropNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetLaminatePly(int uID, int LamNum, int Pos, int PlyPropNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7AddLaminatePly(int uID, int LamNum, int PlyPropNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7DeleteLaminatePly(int uID, int LamNum, int Pos);
        [DllImport("St7API.dll")]
        public static extern int St7InsertLaminatePly(int uID, int LamNum, int Pos, int PlyPropNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetLaminateMatrices(int uID, int LamNum, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetLaminateMatrices(int uID, int LamNum, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7DeleteLaminate(int uID, int LamNum);
        [DllImport("St7API.dll")]
        public static extern int St7DeleteUnusedLaminates(int uID, ref int NumDeleted);
        [DllImport("St7API.dll")]
        public static extern int St7NewReinforcementLayout(int uID, int LayoutID, string LayoutName);
        [DllImport("St7API.dll")]
        public static extern int St7GetReinforcementName(int uID, int LayoutID, StringBuilder LayoutName, int MaxStringLen);
        [DllImport("St7API.dll")]
        public static extern int St7SetReinforcementName(int uID, int LayoutID, string LayoutName);
        [DllImport("St7API.dll")]
        public static extern int St7GetReinforcementData(int uID, int LayoutID, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetReinforcementData(int uID, int LayoutID, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7DeleteReinforcementLayout(int uID, int LayoutID);
        [DllImport("St7API.dll")]
        public static extern int St7NewCreepDefinition(int uID, int CreepID, string CreepDefinitionName);
        [DllImport("St7API.dll")]
        public static extern int St7GetCreepDefinitionName(int uID, int CreepID, StringBuilder CreepDefinitionName, int MaxStringLen);
        [DllImport("St7API.dll")]
        public static extern int St7SetCreepDefinitionName(int uID, int CreepID, string CreepDefinitionName);
        [DllImport("St7API.dll")]
        public static extern int St7GetCreepLaw(int uID, int CreepID, ref int CreepLaw);
        [DllImport("St7API.dll")]
        public static extern int St7SetCreepLaw(int uID, int CreepID, int CreepLaw);
        [DllImport("St7API.dll")]
        public static extern int St7GetCreepBasicData(int uID, int CreepID, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetCreepBasicData(int uID, int CreepID, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7EnableCreepUserTable(int uID, int CreepID, int TableID);
        [DllImport("St7API.dll")]
        public static extern int St7DisableCreepUserTable(int uID, int CreepID, int TableID);
        [DllImport("St7API.dll")]
        public static extern int St7GetCreepUserTableState(int uID, int CreepID, int TableID, ref byte State);
        [DllImport("St7API.dll")]
        public static extern int St7GetCreepUserTableData(int uID, int CreepID, int TableID, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetCreepUserTableData(int uID, int CreepID, int TableID, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetCreepHardeningType(int uID, int CreepID, int[] Integers);
        [DllImport("St7API.dll")]
        public static extern int St7SetCreepHardeningType(int uID, int CreepID, int[] Integers);
        [DllImport("St7API.dll")]
        public static extern int St7GetCreepTimeUnit(int uID, int CreepID, int[] Integers);
        [DllImport("St7API.dll")]
        public static extern int St7SetCreepTimeUnit(int uID, int CreepID, int[] Integers);
        [DllImport("St7API.dll")]
        public static extern int St7GetCreepTemperatureInclude(int uID, int CreepID, ref byte Include);
        [DllImport("St7API.dll")]
        public static extern int St7SetCreepTemperatureInclude(int uID, int CreepID, byte Include);
        [DllImport("St7API.dll")]
        public static extern int St7GetCreepConcreteHyperbolicData(int uID, int CreepID, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetCreepConcreteHyperbolicData(int uID, int CreepID, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetCreepConcreteViscoChainData(int uID, int CreepID, int Pos, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetCreepConcreteViscoChainData(int uID, int CreepID, int Pos, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7EnableCreepConcreteUserTable(int uID, int CreepID, int TableID);
        [DllImport("St7API.dll")]
        public static extern int St7DisableCreepConcreteUserTable(int uID, int CreepID, int TableID);
        [DllImport("St7API.dll")]
        public static extern int St7GetCreepConcreteUserTableState(int uID, int CreepID, int TableID, ref byte State);
        [DllImport("St7API.dll")]
        public static extern int St7GetCreepConcreteUserTableData(int uID, int CreepID, int TableID, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetCreepConcreteUserTableData(int uID, int CreepID, int TableID, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetCreepConcreteFunctionType(int uID, int CreepID, ref int FunctionType);
        [DllImport("St7API.dll")]
        public static extern int St7SetCreepConcreteFunctionType(int uID, int CreepID, int FunctionType);
        [DllImport("St7API.dll")]
        public static extern int St7GetCreepConcreteLoadingAge(int uID, int CreepID, ref double LoadingAge);
        [DllImport("St7API.dll")]
        public static extern int St7SetCreepConcreteLoadingAge(int uID, int CreepID, double LoadingAge);
        [DllImport("St7API.dll")]
        public static extern int St7GetCreepConcreteLoadingTimeUnit(int uID, int CreepID, int[] Integers);
        [DllImport("St7API.dll")]
        public static extern int St7SetCreepConcreteLoadingTimeUnit(int uID, int CreepID, int[] Integers);
        [DllImport("St7API.dll")]
        public static extern int St7GetCreepConcreteShrinkageType(int uID, int CreepID, ref int ShrinkageType);
        [DllImport("St7API.dll")]
        public static extern int St7SetCreepConcreteShrinkageType(int uID, int CreepID, int ShrinkageType);
        [DllImport("St7API.dll")]
        public static extern int St7GetCreepConcreteShrinkageFormulaData(int uID, int CreepID, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetCreepConcreteShrinkageFormulaData(int uID, int CreepID, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetCreepConcreteShrinkageTableData(int uID, int CreepID, ref int TableID);
        [DllImport("St7API.dll")]
        public static extern int St7SetCreepConcreteShrinkageTableData(int uID, int CreepID, int TableID);
        [DllImport("St7API.dll")]
        public static extern int St7GetCreepConcreteTemperatureData(int uID, int CreepID, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetCreepConcreteTemperatureData(int uID, int CreepID, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetCreepConcreteCementCuringData(int uID, int CreepID, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetCreepConcreteCementCuringData(int uID, int CreepID, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7DeleteCreepDefinition(int uID, int CreepID);
        [DllImport("St7API.dll")]
        public static extern int St7NewLoadPathTemplate(int uID, int LoadPathTemplateID, string LoadPathTemplateName);
        [DllImport("St7API.dll")]
        public static extern int St7GetLoadPathTemplateName(int uID, int LoadPathTemplateID, StringBuilder LoadPathTemplateName, int MaxStringLen);
        [DllImport("St7API.dll")]
        public static extern int St7SetLoadPathTemplateName(int uID, int LoadPathTemplateID, string LoadPathTemplateName);
        [DllImport("St7API.dll")]
        public static extern int St7GetLoadPathTemplateParameters(int uID, int LoadPathTemplateID, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetLoadPathTemplateParameters(int uID, int LoadPathTemplateID, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetLoadPathTemplateLaneFactor(int uID, int LoadPathTemplateID, int Lane, ref double Factor);
        [DllImport("St7API.dll")]
        public static extern int St7SetLoadPathTemplateLaneFactor(int uID, int LoadPathTemplateID, int Lane, double Factor);
        [DllImport("St7API.dll")]
        public static extern int St7AddLoadPathTemplateVehicle(int uID, int LoadPathTemplateID);
        [DllImport("St7API.dll")]
        public static extern int St7GetLoadPathTemplateVehicleName(int uID, int LoadPathTemplateID, int Vehicle, StringBuilder LoadPathTemplateVehicleName, int MaxStringLen);
        [DllImport("St7API.dll")]
        public static extern int St7SetLoadPathTemplateVehicleName(int uID, int LoadPathTemplateID, int Vehicle, string LoadPathTemplateVehicleName);
        [DllImport("St7API.dll")]
        public static extern int St7InsertLoadPathTemplateVehicle(int uID, int LoadPathTemplateID, int Vehicle);
        [DllImport("St7API.dll")]
        public static extern int St7CloneLoadPathTemplateVehicle(int uID, int LoadPathTemplateID, int Vehicle);
        [DllImport("St7API.dll")]
        public static extern int St7DeleteLoadPathTemplateVehicle(int uID, int LoadPathTemplateID, int Vehicle);
        [DllImport("St7API.dll")]
        public static extern int St7GetNumLoadPathTemplateVehicles(int uID, int LoadPathTemplateID, ref int NumVehicles);
        [DllImport("St7API.dll")]
        public static extern int St7GetLoadPathTemplateVehicleData(int uID, int LoadPathTemplateID, int Vehicle, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetLoadPathTemplateVehicleData(int uID, int LoadPathTemplateID, int Vehicle, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7EnableLoadPathTemplateVehicleLane(int uID, int LoadPathTemplateID, int Vehicle, int Lane);
        [DllImport("St7API.dll")]
        public static extern int St7DisableLoadPathTemplateVehicleLane(int uID, int LoadPathTemplateID, int Vehicle, int Lane);
        [DllImport("St7API.dll")]
        public static extern int St7GetLoadPathTemplateVehicleLaneState(int uID, int LoadPathTemplateID, int Vehicle, int Lane, ref byte State);
        [DllImport("St7API.dll")]
        public static extern int St7AddLoadPathTemplatePointForce(int uID, int LoadPathTemplateID, int Vehicle);
        [DllImport("St7API.dll")]
        public static extern int St7InsertLoadPathTemplatePointForce(int uID, int LoadPathTemplateID, int Vehicle, int Pos);
        [DllImport("St7API.dll")]
        public static extern int St7DeleteLoadPathTemplatePointForce(int uID, int LoadPathTemplateID, int Vehicle, int Pos);
        [DllImport("St7API.dll")]
        public static extern int St7GetNumLoadPathTemplatePointForces(int uID, int LoadPathTemplateID, int Vehicle, ref int NumPointForces);
        [DllImport("St7API.dll")]
        public static extern int St7GetLoadPathTemplatePointForceData(int uID, int LoadPathTemplateID, int Vehicle, int Pos, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetLoadPathTemplatePointForceData(int uID, int LoadPathTemplateID, int Vehicle, int Pos, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7AddLoadPathTemplateDistributedForce(int uID, int LoadPathTemplateID, int Vehicle);
        [DllImport("St7API.dll")]
        public static extern int St7InsertLoadPathTemplateDistributedForce(int uID, int LoadPathTemplateID, int Vehicle, int Pos);
        [DllImport("St7API.dll")]
        public static extern int St7DeleteLoadPathTemplateDistributedForce(int uID, int LoadPathTemplateID, int Vehicle, int Pos);
        [DllImport("St7API.dll")]
        public static extern int St7GetNumLoadPathTemplateDistributedForces(int uID, int LoadPathTemplateID, int Vehicle, ref int NumDistributedForces);
        [DllImport("St7API.dll")]
        public static extern int St7GetLoadPathTemplateDistributedForceData(int uID, int LoadPathTemplateID, int Vehicle, int Pos, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetLoadPathTemplateDistributedForceData(int uID, int LoadPathTemplateID, int Vehicle, int Pos, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7AddLoadPathTemplateHeatSource(int uID, int LoadPathTemplateID, int Vehicle);
        [DllImport("St7API.dll")]
        public static extern int St7InsertLoadPathTemplateHeatSource(int uID, int LoadPathTemplateID, int Vehicle, int Pos);
        [DllImport("St7API.dll")]
        public static extern int St7DeleteLoadPathTemplateHeatSource(int uID, int LoadPathTemplateID, int Vehicle, int Pos);
        [DllImport("St7API.dll")]
        public static extern int St7GetNumLoadPathTemplateHeatSources(int uID, int LoadPathTemplateID, int Vehicle, ref int NumHeatSources);
        [DllImport("St7API.dll")]
        public static extern int St7GetLoadPathTemplateHeatSourceData(int uID, int LoadPathTemplateID, int Vehicle, int Pos, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetLoadPathTemplateHeatSourceData(int uID, int LoadPathTemplateID, int Vehicle, int Pos, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetLoadPathTemplateVehicleSet(int uID, int LoadPathTemplateID, int Vehicle, StringBuilder LoadPathTemplateVehicleSet, int MaxStringLen);
        [DllImport("St7API.dll")]
        public static extern int St7SetLoadPathTemplateVehicleSet(int uID, int LoadPathTemplateID, int Vehicle, string LoadPathTemplateVehicleSet);
        [DllImport("St7API.dll")]
        public static extern int St7DeleteLoadPathTemplate(int uID, int LoadPathTemplateID);
        [DllImport("St7API.dll")]
        public static extern int St7SetLoadPathTemplateCentrifugalData(int uID, int LoadPathTemplateID, string K0, string K1, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetLoadPathTemplateCentrifugalData(int uID, int LoadPathTemplateID, StringBuilder K0, StringBuilder K1, int MaxStringLen, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetNumLibraries(int uID, int LibraryType, ref int NumLibraries);
        [DllImport("St7API.dll")]
        public static extern int St7GetLibraryName(int uID, int LibraryType, int LibraryID, StringBuilder LibraryName, int MaxStringLen);
        [DllImport("St7API.dll")]
        public static extern int St7GetLibraryID(int uID, int LibraryType, string LibraryName, ref int LibraryID);
        [DllImport("St7API.dll")]
        public static extern int St7GetNumLibraryItems(int uID, int LibraryType, int LibraryID, ref int NumItems);
        [DllImport("St7API.dll")]
        public static extern int St7GetLibraryItemName(int uID, int LibraryType, int LibraryID, int ItemID, StringBuilder ItemName, int MaxStringLen);
        [DllImport("St7API.dll")]
        public static extern int St7GetLibraryItemID(int uID, int LibraryType, int LibraryID, string ItemName, ref int ItemID);
        [DllImport("St7API.dll")]
        public static extern int St7AssignLibraryMaterial(int uID, int Entity, int PropNum, int LibraryID, int ItemID);
        [DllImport("St7API.dll")]
        public static extern int St7AssignLibraryComposite(int uID, int PropNum, int LibraryID, int ItemID);
        [DllImport("St7API.dll")]
        public static extern int St7AssignLibraryBeamSection(int uID, int PropNum, int LibraryID, int ItemID, int[] Integers);
        [DllImport("St7API.dll")]
        public static extern int St7AssignLibraryCreepDefinition(int uID, int CreepID, int LibraryID, int ItemID);
        [DllImport("St7API.dll")]
        public static extern int St7AssignLibraryLoadPathTemplate(int uID, int LoadPathTemplateID, int LibraryID, int ItemID);
        [DllImport("St7API.dll")]
        public static extern int St7AssignLibraryReinforcementLayout(int uID, int LayoutID, int LibraryID, int ItemID);
        [DllImport("St7API.dll")]
        public static extern int St7NewTableType(int uID, int TableType, int TableID, int NumEntries, string TableName, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7DeleteTableType(int uID, int TableType, int TableID);
        [DllImport("St7API.dll")]
        public static extern int St7GetTableTypeName(int uID, int TableType, int TableID, StringBuilder TableName, int MaxStringLen);
        [DllImport("St7API.dll")]
        public static extern int St7GetTableID(int uID, string TableName, int TableType, ref int TableID);
        [DllImport("St7API.dll")]
        public static extern int St7GetNumTableTypeRows(int uID, int TableType, int TableID, ref int NumRows);
        [DllImport("St7API.dll")]
        public static extern int St7GetTableTypeData(int uID, int TableType, int TableID, int MaxRows, ref int NumRows, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetTableTypeData(int uID, int TableType, int TableID, int NumEntries, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetFrequencyTable(int uID, int TableID, ref int FreqType);
        [DllImport("St7API.dll")]
        public static extern int St7SetFrequencyTable(int uID, int TableID, int FreqType);
        [DllImport("St7API.dll")]
        public static extern int St7GetTimeTableUnits(int uID, int TableType, int TableID, ref int UnitType);
        [DllImport("St7API.dll")]
        public static extern int St7SetTimeTableUnits(int uID, int TableType, int TableID, int UnitType);
        [DllImport("St7API.dll")]
        public static extern int St7ConvertTimeTableUnits(int uID, int TableType, int TableID, int UnitType);
        [DllImport("St7API.dll")]
        public static extern int St7GetFrequencyPeriodTableUnits(int uID, int TableID, ref int UnitType);
        [DllImport("St7API.dll")]
        public static extern int St7SetFrequencyPeriodTableUnits(int uID, int TableID, int UnitType);
        [DllImport("St7API.dll")]
        public static extern int St7GetNumTables(int uID, int TableType, ref int NumTables, ref int MaxTableNum);
        [DllImport("St7API.dll")]
        public static extern int St7GetTableInfoByIndex(int uID, int TableType, int Index, ref int TableID, StringBuilder TableName, int MaxStringLen);
        [DllImport("St7API.dll")]
        public static extern int St7EnableLSALoadCase(int uID, int LCaseNum, int FCaseNum);
        [DllImport("St7API.dll")]
        public static extern int St7DisableLSALoadCase(int uID, int LCaseNum, int FCaseNum);
        [DllImport("St7API.dll")]
        public static extern int St7GetLSALoadCaseState(int uID, int LCaseNum, int FCaseNum, ref byte State);
        [DllImport("St7API.dll")]
        public static extern int St7EnableLSAInitialPCGFile(int uID);
        [DllImport("St7API.dll")]
        public static extern int St7DisableLSAInitialPCGFile(int uID);
        [DllImport("St7API.dll")]
        public static extern int St7GetLSAInitialPCGFileState(int uID, ref byte State);
        [DllImport("St7API.dll")]
        public static extern int St7SetLSAInitialPCGFile(int uID, string FileName);
        [DllImport("St7API.dll")]
        public static extern int St7GetLSAInitialPCGFile(int uID, StringBuilder FileName, int MaxStringLen);
        [DllImport("St7API.dll")]
        public static extern int St7SetLBAInitialFile(int uID, string FileName, int CaseNum);
        [DllImport("St7API.dll")]
        public static extern int St7GetLBAInitialFile(int uID, StringBuilder FileName, ref int CaseNum, int MaxStringLen);
        [DllImport("St7API.dll")]
        public static extern int St7SetLBANumModes(int uID, int NumModes);
        [DllImport("St7API.dll")]
        public static extern int St7GetLBANumModes(int uID, ref int NumModes);
        [DllImport("St7API.dll")]
        public static extern int St7SetLBAShift(int uID, double Shift);
        [DllImport("St7API.dll")]
        public static extern int St7GetLBAShift(int uID, ref double Shift);
        [DllImport("St7API.dll")]
        public static extern int St7EnableLIALoadCase(int uID, int LCaseNum, int FCaseNum);
        [DllImport("St7API.dll")]
        public static extern int St7DisableLIALoadCase(int uID, int LCaseNum, int FCaseNum);
        [DllImport("St7API.dll")]
        public static extern int St7GetLIALoadCaseState(int uID, int LCaseNum, int FCaseNum, ref byte State);
        [DllImport("St7API.dll")]
        public static extern int St7SetNLAStagedAnalysis(int uID, byte StagedAnalysis);
        [DllImport("St7API.dll")]
        public static extern int St7GetNLAStagedAnalysis(int uID, ref byte StagedAnalysis);
        [DllImport("St7API.dll")]
        public static extern int St7EnableNLAStage(int uID, int Stage);
        [DllImport("St7API.dll")]
        public static extern int St7DisableNLAStage(int uID, int Stage);
        [DllImport("St7API.dll")]
        public static extern int St7GetNLAStageState(int uID, int Stage, ref byte State);
        [DllImport("St7API.dll")]
        public static extern int St7AddNLAIncrement(int uID, int Stage, string IncName);
        [DllImport("St7API.dll")]
        public static extern int St7InsertNLAIncrement(int uID, int Stage, int Increment, string IncName);
        [DllImport("St7API.dll")]
        public static extern int St7DeleteNLAIncrement(int uID, int Stage, int Increment);
        [DllImport("St7API.dll")]
        public static extern int St7GetNumNLAIncrements(int uID, int Stage, ref int NumIncrements);
        [DllImport("St7API.dll")]
        public static extern int St7SetNLALoadIncrementFactor(int uID, int Stage, int Increment, int CaseNum, double dFactor);
        [DllImport("St7API.dll")]
        public static extern int St7SetNLAFreedomIncrementFactor(int uID, int Stage, int Increment, int CaseNum, double dFactor);
        [DllImport("St7API.dll")]
        public static extern int St7GetNLALoadIncrementFactor(int uID, int Stage, int Increment, int CaseNum, ref double dFactor);
        [DllImport("St7API.dll")]
        public static extern int St7GetNLAFreedomIncrementFactor(int uID, int Stage, int Increment, int CaseNum, ref double dFactor);
        [DllImport("St7API.dll")]
        public static extern int St7EnableNLALoadCase(int uID, int Stage, int CaseNum);
        [DllImport("St7API.dll")]
        public static extern int St7DisableNLALoadCase(int uID, int Stage, int CaseNum);
        [DllImport("St7API.dll")]
        public static extern int St7EnableNLAFreedomCase(int uID, int Stage, int CaseNum);
        [DllImport("St7API.dll")]
        public static extern int St7DisableNLAFreedomCase(int uID, int Stage, int CaseNum);
        [DllImport("St7API.dll")]
        public static extern int St7GetNLALoadCaseState(int uID, int Stage, int CaseNum, ref byte State);
        [DllImport("St7API.dll")]
        public static extern int St7GetNLAFreedomCaseState(int uID, int Stage, int CaseNum, ref byte State);
        [DllImport("St7API.dll")]
        public static extern int St7SetNLAInitialFile(int uID, string FileName, int CaseNum);
        [DllImport("St7API.dll")]
        public static extern int St7GetNLAInitialFile(int uID, StringBuilder FileName, ref int CaseNum, int MaxStringLen);
        [DllImport("St7API.dll")]
        public static extern int St7SetQSAInitialFile(int uID, string FileName, int CaseNum);
        [DllImport("St7API.dll")]
        public static extern int St7GetQSAInitialFile(int uID, StringBuilder FileName, ref int CaseNum, int MaxStringLen);
        [DllImport("St7API.dll")]
        public static extern int St7SetNFAInitialFile(int uID, string FileName, int CaseNum);
        [DllImport("St7API.dll")]
        public static extern int St7GetNFAInitialFile(int uID, StringBuilder FileName, ref int CaseNum, int MaxStringLen);
        [DllImport("St7API.dll")]
        public static extern int St7EnableNFANonStructuralMassCase(int uID, int CaseNum);
        [DllImport("St7API.dll")]
        public static extern int St7DisableNFANonStructuralMassCase(int uID, int CaseNum);
        [DllImport("St7API.dll")]
        public static extern int St7GetNFANonStructuralMassCaseState(int uID, int CaseNum, ref byte State);
        [DllImport("St7API.dll")]
        public static extern int St7SetNFANumModes(int uID, int NumModes);
        [DllImport("St7API.dll")]
        public static extern int St7GetNFANumModes(int uID, ref int NumModes);
        [DllImport("St7API.dll")]
        public static extern int St7SetNFAShift(int uID, double Shift);
        [DllImport("St7API.dll")]
        public static extern int St7GetNFAShift(int uID, ref double Shift);
        [DllImport("St7API.dll")]
        public static extern int St7SetNFAModeParticipationCalculate(int uID, byte Calculate);
        [DllImport("St7API.dll")]
        public static extern int St7GetNFAModeParticipationCalculate(int uID, ref byte Calculate);
        [DllImport("St7API.dll")]
        public static extern int St7SetNFAModeParticipationVectors(int uID, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetNFAModeParticipationVectors(int uID, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetHRARange(int uID, int NumSteps, double F1, double F2, byte AutoInsert);
        [DllImport("St7API.dll")]
        public static extern int St7GetHRARange(int uID, ref int NumSteps, ref double F1, ref double F2, ref byte AutoInsert);
        [DllImport("St7API.dll")]
        public static extern int St7SetHRAResultType(int uID, int lType);
        [DllImport("St7API.dll")]
        public static extern int St7GetHRAResultType(int uID, ref int lType);
        [DllImport("St7API.dll")]
        public static extern int St7SetHRABaseVector(int uID, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetHRABaseVector(int uID, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetHRALoadCase(int uID, int CaseNum, int TableID, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetHRALoadCase(int uID, int CaseNum, ref int TableID, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7AddSRALoadCase(int uID, string CaseName);
        [DllImport("St7API.dll")]
        public static extern int St7InsertSRALoadCase(int uID, int Pos, string CaseName);
        [DllImport("St7API.dll")]
        public static extern int St7DeleteSRALoadCase(int uID, int Pos);
        [DllImport("St7API.dll")]
        public static extern int St7GetNumSRALoadCases(int uID, ref int NumCases);
        [DllImport("St7API.dll")]
        public static extern int St7SetSRALoadCaseTable(int uID, int Pos, int CaseNum, int TableID);
        [DllImport("St7API.dll")]
        public static extern int St7GetSRALoadCaseTable(int uID, int Pos, int CaseNum, ref int TableID);
        [DllImport("St7API.dll")]
        public static extern int St7AddSRADirectionVector(int uID, string CaseName);
        [DllImport("St7API.dll")]
        public static extern int St7InsertSRADirectionVector(int uID, int Pos, string CaseName);
        [DllImport("St7API.dll")]
        public static extern int St7DeleteSRADirectionVector(int uID, int Pos);
        [DllImport("St7API.dll")]
        public static extern int St7GetNumSRADirectionVectors(int uID, ref int NumCases);
        [DllImport("St7API.dll")]
        public static extern int St7SetSRADirectionVectorTable(int uID, int Pos, int TableID);
        [DllImport("St7API.dll")]
        public static extern int St7GetSRADirectionVectorTable(int uID, int Pos, ref int TableID);
        [DllImport("St7API.dll")]
        public static extern int St7SetSRADirectionVectorFactors(int uID, int Pos, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetSRADirectionVectorFactors(int uID, int Pos, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetSRAResultModal(int uID, byte Modal);
        [DllImport("St7API.dll")]
        public static extern int St7SetSRAResultSRSS(int uID, byte SRSS);
        [DllImport("St7API.dll")]
        public static extern int St7SetSRAResultCQC(int uID, byte CQC);
        [DllImport("St7API.dll")]
        public static extern int St7SetSRAType(int uID, int SpectrumType);
        [DllImport("St7API.dll")]
        public static extern int St7SetSRAResultsSign(int uID, int ResultsSign);
        [DllImport("St7API.dll")]
        public static extern int St7SetLTAInitialFile(int uID, string FileName, int CaseNum);
        [DllImport("St7API.dll")]
        public static extern int St7GetLTAInitialFile(int uID, StringBuilder FileName, ref int CaseNum, int MaxStringLen);
        [DllImport("St7API.dll")]
        public static extern int St7SetLTAMethod(int uID, int Method);
        [DllImport("St7API.dll")]
        public static extern int St7GetLTAMethod(int uID, ref int Method);
        [DllImport("St7API.dll")]
        public static extern int St7SetLTASolutionType(int uID, int SolutionType);
        [DllImport("St7API.dll")]
        public static extern int St7GetLTASolutionType(int uID, ref int SolutionType);
        [DllImport("St7API.dll")]
        public static extern int St7SetNTAInitialFile(int uID, string FileName, int CaseNum);
        [DllImport("St7API.dll")]
        public static extern int St7GetNTAInitialFile(int uID, StringBuilder FileName, ref int CaseNum, int MaxStringLen);
        [DllImport("St7API.dll")]
        public static extern int St7SetNTALoadPositionTable(int uID, int CaseNum, int TableNum, int UCSId, int Axis);
        [DllImport("St7API.dll")]
        public static extern int St7GetNTALoadPositionTable(int uID, int CaseNum, ref int TableNum, ref int UCSId, ref int Axis);
        [DllImport("St7API.dll")]
        public static extern int St7SetNTAFreedomPositionTable(int uID, int CaseNum, int TableNum, int UCSId, int Axis);
        [DllImport("St7API.dll")]
        public static extern int St7GetNTAFreedomPositionTable(int uID, int CaseNum, ref int TableNum, ref int UCSId, ref int Axis);
        [DllImport("St7API.dll")]
        public static extern int St7EnableHeatLoadCase(int uID, int CaseNum);
        [DllImport("St7API.dll")]
        public static extern int St7DisableHeatLoadCase(int uID, int CaseNum);
        [DllImport("St7API.dll")]
        public static extern int St7GetHeatLoadCaseState(int uID, int CaseNum, ref byte State);
        [DllImport("St7API.dll")]
        public static extern int St7SetTHAInitialFile(int uID, string FileName, int CaseNum);
        [DllImport("St7API.dll")]
        public static extern int St7GetTHAInitialFile(int uID, StringBuilder FileName, ref int CaseNum, int MaxStringLen);
        [DllImport("St7API.dll")]
        public static extern int St7SetTHATemperatureLoadCase(int uID, int CaseNum);
        [DllImport("St7API.dll")]
        public static extern int St7GetTHATemperatureLoadCase(int uID, ref int CaseNum);
        [DllImport("St7API.dll")]
        public static extern int St7GetModalLoadType(int uID, ref int lType);
        [DllImport("St7API.dll")]
        public static extern int St7SetModalLoadType(int uID, int lType);
        [DllImport("St7API.dll")]
        public static extern int St7GetModalNodeReactionType(int uID, ref int rType);
        [DllImport("St7API.dll")]
        public static extern int St7SetModalNodeReactionType(int uID, int rType);
        [DllImport("St7API.dll")]
        public static extern int St7SetModalSuperpositionFile(int uID, string FileName);
        [DllImport("St7API.dll")]
        public static extern int St7GetModalSuperpositionFile(int uID, StringBuilder FileName, int MaxStringLen);
        [DllImport("St7API.dll")]
        public static extern int St7GetNumModesInModalFile(int uID, ref int NumModes);
        [DllImport("St7API.dll")]
        public static extern int St7EnableMode(int uID, int ModeNum);
        [DllImport("St7API.dll")]
        public static extern int St7DisableMode(int uID, int ModeNum);
        [DllImport("St7API.dll")]
        public static extern int St7SetModeDampingRatio(int uID, int ModeNum, double Ratio);
        [DllImport("St7API.dll")]
        public static extern int St7GetModeDampingRatio(int uID, int ModeNum, ref double Ratio);
        [DllImport("St7API.dll")]
        public static extern int St7SetTransientInitialConditionsType(int uID, int InitialType);
        [DllImport("St7API.dll")]
        public static extern int St7GetTransientInitialConditionsType(int uID, ref int InitialType);
        [DllImport("St7API.dll")]
        public static extern int St7SetTransientInitialConditionsVectors(int uID, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetTransientInitialConditionsVectors(int uID, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetTransientInitialConditionsNodalVelocity(int uID, int CaseNum);
        [DllImport("St7API.dll")]
        public static extern int St7GetTransientInitialConditionsNodalVelocity(int uID, ref int CaseNum);
        [DllImport("St7API.dll")]
        public static extern int St7GetTransientBaseVector(int uID, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetTransientBaseVector(int uID, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetTransientBaseVelocity(int uID, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetTransientBaseVelocity(int uID, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetTransientBaseTables(int uID, int[] Integers);
        [DllImport("St7API.dll")]
        public static extern int St7SetTransientBaseTables(int uID, int[] Integers);
        [DllImport("St7API.dll")]
        public static extern int St7GetTransientBaseResults(int uID, byte[] Logicals);
        [DllImport("St7API.dll")]
        public static extern int St7SetTransientBaseResults(int uID, byte[] Logicals);
        [DllImport("St7API.dll")]
        public static extern int St7AddTransientNodeHistoryCase(int uID, int NodeNum);
        [DllImport("St7API.dll")]
        public static extern int St7InsertTransientNodeHistoryCase(int uID, int NodeNum, int Pos);
        [DllImport("St7API.dll")]
        public static extern int St7DeleteTransientNodeHistoryCase(int uID, int Pos);
        [DllImport("St7API.dll")]
        public static extern int St7GetNumTransientNodeHistoryCases(int uID, ref int NumCases);
        [DllImport("St7API.dll")]
        public static extern int St7SetTransientNodeHistoryCaseData(int uID, int Pos, byte[] Logicals);
        [DllImport("St7API.dll")]
        public static extern int St7GetTransientNodeHistoryCaseData(int uID, int Pos, byte[] Logicals);
        [DllImport("St7API.dll")]
        public static extern int St7SetTransientTemperatureInputType(int uID, int InputType);
        [DllImport("St7API.dll")]
        public static extern int St7SetTransientHeatFile(int uID, string FileName, double RefTemp);
        [DllImport("St7API.dll")]
        public static extern int St7GetTransientHeatFile(int uID, StringBuilder FileName, int MaxStringLen, ref double RefTemp);
        [DllImport("St7API.dll")]
        public static extern int St7EnableTransientLoadCase(int uID, int CaseNum);
        [DllImport("St7API.dll")]
        public static extern int St7EnableTransientFreedomCase(int uID, int CaseNum);
        [DllImport("St7API.dll")]
        public static extern int St7DisableTransientLoadCase(int uID, int CaseNum);
        [DllImport("St7API.dll")]
        public static extern int St7DisableTransientFreedomCase(int uID, int CaseNum);
        [DllImport("St7API.dll")]
        public static extern int St7GetTransientLoadCaseState(int uID, int CaseNum, ref byte State);
        [DllImport("St7API.dll")]
        public static extern int St7GetTransientFreedomCaseState(int uID, int CaseNum, ref byte State);
        [DllImport("St7API.dll")]
        public static extern int St7SetTransientLoadTable(int uID, int CaseNum, int TableNum);
        [DllImport("St7API.dll")]
        public static extern int St7GetTransientLoadTable(int uID, int CaseNum, ref int TableNum);
        [DllImport("St7API.dll")]
        public static extern int St7SetTransientFreedomTable(int uID, int CaseNum, int TableNum);
        [DllImport("St7API.dll")]
        public static extern int St7GetTransientFreedomTable(int uID, int CaseNum, ref int TableNum);
        [DllImport("St7API.dll")]
        public static extern int St7GetNumTimeStepRows(int uID, ref int NumRows);
        [DllImport("St7API.dll")]
        public static extern int St7SetNumTimeStepRows(int uID, int NumRows);
        [DllImport("St7API.dll")]
        public static extern int St7GetTimeStepData(int uID, int Row, ref int NumSteps, ref int SaveEvery, ref double TimeStep);
        [DllImport("St7API.dll")]
        public static extern int St7SetTimeStepData(int uID, int Row, int NumSteps, int SaveEvery, double TimeStep);
        [DllImport("St7API.dll")]
        public static extern int St7SetTimeStepUnit(int uID, int TimeUnit);
        [DllImport("St7API.dll")]
        public static extern int St7GetTimeStepUnit(int uID, ref int TimeUnit);
        [DllImport("St7API.dll")]
        public static extern int St7EnableMovingLoad(int uID, int LoadPathID);
        [DllImport("St7API.dll")]
        public static extern int St7DisableMovingLoad(int uID, int LoadPathID);
        [DllImport("St7API.dll")]
        public static extern int St7GetMovingLoadState(int uID, int LoadPathID, ref byte State);
        [DllImport("St7API.dll")]
        public static extern int St7SetSolverHeatNonlinear(int uID, byte Nonlinear);
        [DllImport("St7API.dll")]
        public static extern int St7SetSolverScheme(int uID, int Solver);
        [DllImport("St7API.dll")]
        public static extern int St7GetSolverScheme(int uID, ref int Solver);
        [DllImport("St7API.dll")]
        public static extern int St7SetSolverSort(int uID, int Sort);
        [DllImport("St7API.dll")]
        public static extern int St7GetSolverSort(int uID, ref int Sort);
        [DllImport("St7API.dll")]
        public static extern int St7SetSolverTreeStartNumber(int uID, int Start);
        [DllImport("St7API.dll")]
        public static extern int St7GetSolverTreeStartNumber(int uID, ref int Start);
        [DllImport("St7API.dll")]
        public static extern int St7SetSolverActiveStage(int uID, int Stage);
        [DllImport("St7API.dll")]
        public static extern int St7GetSolverActiveStage(int uID, ref int Stage);
        [DllImport("St7API.dll")]
        public static extern int St7SetSolverTemperatureDependence(int uID, int TempType);
        [DllImport("St7API.dll")]
        public static extern int St7GetSolverTemperatureDependence(int uID, ref int TempType);
        [DllImport("St7API.dll")]
        public static extern int St7SetSolverLoadCaseTemperatureDependence(int uID, int CaseNum);
        [DllImport("St7API.dll")]
        public static extern int St7GetSolverLoadCaseTemperatureDependence(int uID, ref int CaseNum);
        [DllImport("St7API.dll")]
        public static extern int St7SetSolverFreedomCase(int uID, int CaseNum);
        [DllImport("St7API.dll")]
        public static extern int St7GetSolverFreedomCase(int uID, ref int CaseNum);
        [DllImport("St7API.dll")]
        public static extern int St7SetDampingType(int uID, int DampType);
        [DllImport("St7API.dll")]
        public static extern int St7GetDampingType(int uID, ref int DampType);
        [DllImport("St7API.dll")]
        public static extern int St7SetRayleighFactors(int uID, int RayleighMode, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetRayleighFactors(int uID, ref int RayleighMode, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetSoilFluidOptions(int uID, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetSoilFluidOptions(int uID, ref int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetSturmCheck(int uID, byte DoSturm);
        [DllImport("St7API.dll")]
        public static extern int St7GetSturmCheck(int uID, ref byte DoSturm);
        [DllImport("St7API.dll")]
        public static extern int St7SetSolverNonlinearGeometry(int uID, byte NonlinearGeometry);
        [DllImport("St7API.dll")]
        public static extern int St7GetSolverNonlinearGeometry(int uID, ref byte NonlinearGeometry);
        [DllImport("St7API.dll")]
        public static extern int St7SetSolverNonlinearMaterial(int uID, byte NonlinearMaterial);
        [DllImport("St7API.dll")]
        public static extern int St7GetSolverNonlinearMaterial(int uID, ref byte NonlinearMaterial);
        [DllImport("St7API.dll")]
        public static extern int St7SetSolverCreep(int uID, byte Creep);
        [DllImport("St7API.dll")]
        public static extern int St7GetSolverCreep(int uID, ref byte Creep);
        [DllImport("St7API.dll")]
        public static extern int St7SetSolverIncludeKG(int uID, byte IncludeKG);
        [DllImport("St7API.dll")]
        public static extern int St7GetSolverIncludeKG(int uID, ref byte IncludeKG);
        [DllImport("St7API.dll")]
        public static extern int St7SetSolverStressStiffening(int uID, byte AddStressStiffening);
        [DllImport("St7API.dll")]
        public static extern int St7GetSolverStressStiffening(int uID, ref byte AddStressStiffening);
        [DllImport("St7API.dll")]
        public static extern int St7SetEntityResult(int uID, int Result, int State);
        [DllImport("St7API.dll")]
        public static extern int St7GetEntityResult(int uID, int Result, ref int State);
        [DllImport("St7API.dll")]
        public static extern int St7SetResultSurfaceBricksOnly(int uID, int State);
        [DllImport("St7API.dll")]
        public static extern int St7GetResultSurfaceBricksOnly(int uID, ref int State);
        [DllImport("St7API.dll")]
        public static extern int St7SetResultLimit(int uID, int Entity, int State, double Limit);
        [DllImport("St7API.dll")]
        public static extern int St7GetResultLimit(int uID, int Entity, ref int State, ref double Limit);
        [DllImport("St7API.dll")]
        public static extern int St7EnableResultGroup(int uID, int GroupID);
        [DllImport("St7API.dll")]
        public static extern int St7DisableResultGroup(int uID, int GroupID);
        [DllImport("St7API.dll")]
        public static extern int St7GetResultGroupState(int uID, int GroupID, ref byte State);
        [DllImport("St7API.dll")]
        public static extern int St7EnableResultProperty(int uID, int Entity, int PropNum);
        [DllImport("St7API.dll")]
        public static extern int St7DisableResultProperty(int uID, int Entity, int PropNum);
        [DllImport("St7API.dll")]
        public static extern int St7GetResultPropertyState(int uID, int Entity, int PropNum, ref byte State);
        [DllImport("St7API.dll")]
        public static extern int St7SetResultFileName(int uID, string FileName);
        [DllImport("St7API.dll")]
        public static extern int St7SetResultLogFileName(int uID, string LogName);
        [DllImport("St7API.dll")]
        public static extern int St7SetStaticRestartFile(int uID, string FileName);
        [DllImport("St7API.dll")]
        public static extern int St7GetStaticRestartFile(int uID, StringBuilder FileName, int MaxStringLen);
        [DllImport("St7API.dll")]
        public static extern int St7SetDynamicRestartFile(int uID, string FileName);
        [DllImport("St7API.dll")]
        public static extern int St7GetDynamicRestartFile(int uID, StringBuilder FileName, int MaxStringLen);
        [DllImport("St7API.dll")]
        public static extern int St7SetQuasiStaticRestartFile(int uID, string FileName);
        [DllImport("St7API.dll")]
        public static extern int St7GetQuasiStaticRestartFile(int uID, StringBuilder FileName, int MaxStringLen);
        [DllImport("St7API.dll")]
        public static extern int St7SetNodeHistoryFile(int uID, string FileName);
        [DllImport("St7API.dll")]
        public static extern int St7GetNodeHistoryFile(int uID, StringBuilder FileName, int MaxStringLen);
        [DllImport("St7API.dll")]
        public static extern int St7EnableSaveRestart(int uID);
        [DllImport("St7API.dll")]
        public static extern int St7DisableSaveRestart(int uID);
        [DllImport("St7API.dll")]
        public static extern int St7EnableSaveLastRestartStep(int uID);
        [DllImport("St7API.dll")]
        public static extern int St7DisableSaveLastRestartStep(int uID);
        [DllImport("St7API.dll")]
        public static extern int St7EnableAutoAssignPathDivisions(int uID);
        [DllImport("St7API.dll")]
        public static extern int St7DisableAutoAssignPathDivisions(int uID);
        [DllImport("St7API.dll")]
        public static extern int St7SetSolverDefaultsLogical(int uID, int Parameter, byte pValue);
        [DllImport("St7API.dll")]
        public static extern int St7GetSolverDefaultsLogical(int uID, int Parameter, ref byte pValue);
        [DllImport("St7API.dll")]
        public static extern int St7SetSolverDefaultsInteger(int uID, int Parameter, int pValue);
        [DllImport("St7API.dll")]
        public static extern int St7GetSolverDefaultsInteger(int uID, int Parameter, ref int pValue);
        [DllImport("St7API.dll")]
        public static extern int St7SetSolverDefaultsDouble(int uID, int Parameter, double pValue);
        [DllImport("St7API.dll")]
        public static extern int St7GetSolverDefaultsDouble(int uID, int Parameter, ref double pValue);
        [DllImport("St7API.dll")]
        public static extern int St7RunSolver(int uID, int Solver, int Mode, int Wait);
        [DllImport("St7API.dll")]
        public static extern int St7RunSolverProcess(int uID, int Solver, int Mode, int Wait, ref int ProcessID);
        [DllImport("St7API.dll")]
        public static extern int St7CheckSolverRunning(int ProcessID, ref byte IsRunning);
        [DllImport("St7API.dll")]
        public static extern int St7GetResultCaseName(int uID, int CaseNum, StringBuilder CaseName, int MaxStringLen);
        [DllImport("St7API.dll")]
        public static extern int St7GetResultFreedomCaseName(int uID, StringBuilder CaseName, int MaxStringLen);
        [DllImport("St7API.dll")]
        public static extern int St7GetResultCaseConvergence(int uID, int CaseNum, ref byte Converged);
        [DllImport("St7API.dll")]
        public static extern int St7GetResultCaseTime(int uID, int CaseNum, ref double Time);
        [DllImport("St7API.dll")]
        public static extern int St7GetResultCaseFactor(int uID, int CaseNum, ref double Factor);
        [DllImport("St7API.dll")]
        public static extern int St7GetFrequency(int uID, int Mode, ref double Freq);
        [DllImport("St7API.dll")]
        public static extern int St7GetModalResultsNFA(int uID, int Mode, double[] ModalRes);
        [DllImport("St7API.dll")]
        public static extern int St7GetInertiaReliefResults(int uID, int CaseNum, double[] InertiaRes);
        [DllImport("St7API.dll")]
        public static extern int St7GetBuckFactor(int uID, int Mode, ref double Fact);
        [DllImport("St7API.dll")]
        public static extern int St7GetNodeResult(int uID, int ResultType, int NodeNum, int ResultCase, double[] NodeRes);
        [DllImport("St7API.dll")]
        public static extern int St7GetNodeResultUCS(int uID, int ResultType, int UCSId, int NodeNum, int ResultCase, double[] NodeRes);
        [DllImport("St7API.dll")]
        public static extern int St7GetBeamResultArray(int uID, int ResultType, int ResultSubType, int BeamNum, int MinStations, int ResultCase, ref int NumStations, ref int NumColumns, double[] BeamPos, double[] BeamRes);
        [DllImport("St7API.dll")]
        public static extern int St7GetBeamResultArrayPos(int uID, int ResultType, int ResultSubType, int BeamNum, int ResultCase, int NumStations, double[] BeamPos, ref int NumColumns, double[] BeamRes);
        [DllImport("St7API.dll")]
        public static extern int St7GetBeamResultEndPos(int uID, int ResultType, int ResultSubType, int BeamNum, int ResultCase, ref int NumColumns, double[] BeamRes);
        [DllImport("St7API.dll")]
        public static extern int St7GetBeamResultSinglePos(int uID, int ResultType, int ResultSubType, int BeamNum, int ResultCase, double Position, ref int NumColumns, double[] BeamRes);
        [DllImport("St7API.dll")]
        public static extern int St7GetBeamReleaseResult(int uID, int BeamNum, int ResultCase, byte[] BeamReleased, double[] ReleaseValue);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlateResultArray(int uID, int ResultType, int ResultSubType, int PlateNum, int ResultCase, int SampleLocation, int Surface, int Layer, ref int NumPoints, ref int NumColumns, double[] PlateResult);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlateResultMaxJunctionAngle(int uID, double MaxJunctionAngle);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlateResultMaxJunctionAngle(int uID, ref double MaxJunctionAngle);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlateResultUserEquation(int uID, string Equation, int TrigType);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlateResultUserEquation(int uID, StringBuilder Equation, int MaxStringLen, ref int TrigType);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlateResultGaussPoints(int uID, int PlateNum, int ResultCase, ref int NumGauss, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetBrickResultArray(int uID, int ResultType, int ResultSubType, int BrickNum, int ResultCase, int SampleLocation, ref int NumPoints, ref int NumColumns, double[] BrickRes);
        [DllImport("St7API.dll")]
        public static extern int St7SetBrickResultUserEquation(int uID, string Equation, int TrigType);
        [DllImport("St7API.dll")]
        public static extern int St7GetBrickResultUserEquation(int uID, StringBuilder Equation, int MaxStringLen, ref int TrigType);
        [DllImport("St7API.dll")]
        public static extern int St7GetBrickResultGaussPoints(int uID, int BrickNum, int ResultCase, ref int NumGauss, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetNumLSACombinations(int uID, ref int NumCases);
        [DllImport("St7API.dll")]
        public static extern int St7GetLSACombinationName(int uID, int CaseNum, StringBuilder CaseName, int MaxStringLen);
        [DllImport("St7API.dll")]
        public static extern int St7SetLSACombinationName(int uID, int CaseNum, string CaseName);
        [DllImport("St7API.dll")]
        public static extern int St7GetLSACombinationSpectralName(int uID, StringBuilder FileName, int MaxStringLen);
        [DllImport("St7API.dll")]
        public static extern int St7SetLSACombinationSpectralName(int uID, string FileName);
        [DllImport("St7API.dll")]
        public static extern int St7AddLSACombination(int uID, string IncName);
        [DllImport("St7API.dll")]
        public static extern int St7InsertLSACombination(int uID, int Pos, string IncName);
        [DllImport("St7API.dll")]
        public static extern int St7DeleteLSACombination(int uID, int Pos);
        [DllImport("St7API.dll")]
        public static extern int St7SetLSACombinationFactor(int uID, int LType, int Pos, int LCaseNum, int FCaseNum, double Factor);
        [DllImport("St7API.dll")]
        public static extern int St7GetLSACombinationFactor(int uID, int LType, int Pos, int LCaseNum, int FCaseNum, ref double Factor);
        [DllImport("St7API.dll")]
        public static extern int St7GetNumEnvelopes(int uID, ref int NumLimitEnvelopes, ref int NumCombinationEnvelopes, ref int NumFactorsEnvelopes);
        [DllImport("St7API.dll")]
        public static extern int St7AddLimitEnvelope(int uID, int EnvType, string EnvName);
        [DllImport("St7API.dll")]
        public static extern int St7InsertLimitEnvelope(int uID, int Envelope, int EnvType, string EnvName);
        [DllImport("St7API.dll")]
        public static extern int St7DeleteLimitEnvelope(int uID, int Envelope);
        [DllImport("St7API.dll")]
        public static extern int St7EnableLimitEnvelopeCase(int uID, int Envelope, int CaseNum);
        [DllImport("St7API.dll")]
        public static extern int St7DisableLimitEnvelopeCase(int uID, int Envelope, int CaseNum);
        [DllImport("St7API.dll")]
        public static extern int St7GetLimitEnvelopeCaseState(int uID, int Envelope, int CaseNum, ref byte State);
        [DllImport("St7API.dll")]
        public static extern int St7GetLimitEnvelopeData(int uID, int Envelope, ref int EnvType, StringBuilder EnvName, int MaxStringLen);
        [DllImport("St7API.dll")]
        public static extern int St7SetLimitEnvelopeData(int uID, int Envelope, int EnvType, string EnvName);
        [DllImport("St7API.dll")]
        public static extern int St7AddCombinationEnvelope(int uID, int EnvType, string EnvName);
        [DllImport("St7API.dll")]
        public static extern int St7InsertCombinationEnvelope(int uID, int Envelope, int EnvType, string EnvName);
        [DllImport("St7API.dll")]
        public static extern int St7DeleteCombinationEnvelope(int uID, int Envelope);
        [DllImport("St7API.dll")]
        public static extern int St7GetCombinationEnvelopeCase(int uID, int Envelope, int CaseNum, ref int State);
        [DllImport("St7API.dll")]
        public static extern int St7SetCombinationEnvelopeCase(int uID, int Envelope, int CaseNum, int State);
        [DllImport("St7API.dll")]
        public static extern int St7GetCombinationEnvelopeData(int uID, int Envelope, ref int EnvType, StringBuilder EnvName, int MaxStringLen);
        [DllImport("St7API.dll")]
        public static extern int St7SetCombinationEnvelopeData(int uID, int Envelope, int EnvType, string EnvName);
        [DllImport("St7API.dll")]
        public static extern int St7AddFactorsEnvelope(int uID, int EnvType, string EnvName);
        [DllImport("St7API.dll")]
        public static extern int St7InsertFactorsEnvelope(int uID, int Envelope, int EnvType, string EnvName);
        [DllImport("St7API.dll")]
        public static extern int St7DeleteFactorsEnvelope(int uID, int Envelope);
        [DllImport("St7API.dll")]
        public static extern int St7GetFactorsEnvelopeData(int uID, int Envelope, ref int EnvType, StringBuilder EnvName, int MaxStringLen);
        [DllImport("St7API.dll")]
        public static extern int St7SetFactorsEnvelopeData(int uID, int Envelope, int EnvType, string EnvName);
        [DllImport("St7API.dll")]
        public static extern int St7AddFactorsEnvelopeCase(int uID, int Envelope);
        [DllImport("St7API.dll")]
        public static extern int St7InsertFactorsEnvelopeCase(int uID, int Envelope, int Pos);
        [DllImport("St7API.dll")]
        public static extern int St7DeleteFactorsEnvelopeCase(int uID, int Envelope, int Pos);
        [DllImport("St7API.dll")]
        public static extern int St7GetFactorsEnvelopeCaseData(int uID, int Envelope, int Pos, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetFactorsEnvelopeCaseData(int uID, int Envelope, int Pos, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7AddFactorsEnvelopeSet(int uID);
        [DllImport("St7API.dll")]
        public static extern int St7InsertFactorsEnvelopeSet(int uID, int Pos);
        [DllImport("St7API.dll")]
        public static extern int St7DeleteFactorsEnvelopeSet(int uID, int Pos);
        [DllImport("St7API.dll")]
        public static extern int St7GetNumFactorsEnvelopeSets(int uID, ref int NumSets);
        [DllImport("St7API.dll")]
        public static extern int St7GetFactorsEnvelopeSetData(int uID, int Pos, ref int SetType, StringBuilder SetName, StringBuilder SetGroup, int MaxStringLen);
        [DllImport("St7API.dll")]
        public static extern int St7SetFactorsEnvelopeSetData(int uID, int Pos, int SetType, string SetName, string SetGroup);
        [DllImport("St7API.dll")]
        public static extern int St7GetResultFileCombTargetFileName(int uID, StringBuilder FileName, int MaxStringLen);
        [DllImport("St7API.dll")]
        public static extern int St7SetResultFileCombTargetFileName(int uID, string FileName);
        [DllImport("St7API.dll")]
        public static extern int St7AddResultFileCombFileName(int uID, string FileName);
        [DllImport("St7API.dll")]
        public static extern int St7DeleteResultFileCombFileName(int uID, int FileNum);
        [DllImport("St7API.dll")]
        public static extern int St7GetResultFileCombFileName(int uID, int FileNum, StringBuilder FileName, int MaxStringLen);
        [DllImport("St7API.dll")]
        public static extern int St7SetResultFileCombFileName(int uID, int FileNum, string FileName);
        [DllImport("St7API.dll")]
        public static extern int St7AddResultFileCombCase(int uID, string CaseName);
        [DllImport("St7API.dll")]
        public static extern int St7DeleteResultFileCombCase(int uID);
        [DllImport("St7API.dll")]
        public static extern int St7GetResultFileCombCaseData(int uID, int FileNum, int Pos, ref int CaseNum, ref double Factor);
        [DllImport("St7API.dll")]
        public static extern int St7SetResultFileCombCaseData(int uID, int FileNum, int Pos, int CaseNum, double Factor);
        [DllImport("St7API.dll")]
        public static extern int St7GetResultFileCombCaseName(int uID, int Pos, StringBuilder CaseName, int MaxStringLen);
        [DllImport("St7API.dll")]
        public static extern int St7SetResultFileCombCaseName(int uID, int Pos, string CaseName);
        [DllImport("St7API.dll")]
        public static extern int St7GenerateResultFileComb(int uID, int Method);
        [DllImport("St7API.dll")]
        public static extern int St7UpdateResultFileComb(int uID, string FileName);
        [DllImport("St7API.dll")]
        public static extern int St7GenerateHRATimeHistory(int uID, double StartTime, double EndTime, int NumSteps);
        [DllImport("St7API.dll")]
        public static extern int St7NewResFile(int uID, string FileName, int ResultType);
        [DllImport("St7API.dll")]
        public static extern int St7OpenResFile(int uID, string FileName);
        [DllImport("St7API.dll")]
        public static extern int St7CloseResFile(int uID);
        [DllImport("St7API.dll")]
        public static extern int St7SetResFileDescription(int uID, string Name);
        [DllImport("St7API.dll")]
        public static extern int St7GetResFileDescription(int uID, StringBuilder Name, int MaxStringLen);
        [DllImport("St7API.dll")]
        public static extern int St7SetResFileNumCases(int uID, int NumCases);
        [DllImport("St7API.dll")]
        public static extern int St7SetResFileCaseName(int uID, int CaseNum, string CaseName);
        [DllImport("St7API.dll")]
        public static extern int St7AssociateResFileCase(int uID, int CaseNum, int LoadCase, int FreedomCase);
        [DllImport("St7API.dll")]
        public static extern int St7AssociateResFileStage(int uID, int CaseNum, int StageNum);
        [DllImport("St7API.dll")]
        public static extern int St7SetResFileMode(int uID, int CaseNum, double Mode);
        [DllImport("St7API.dll")]
        public static extern int St7GetResFileMode(int uID, int CaseNum, ref double Mode);
        [DllImport("St7API.dll")]
        public static extern int St7SetResFileTime(int uID, int CaseNum, double Time);
        [DllImport("St7API.dll")]
        public static extern int St7GetResFileTime(int uID, int CaseNum, ref double Time);
        [DllImport("St7API.dll")]
        public static extern int St7SetResFileTimeUnit(int uID, int TimeUnit);
        [DllImport("St7API.dll")]
        public static extern int St7GetResFileTimeUnit(int uID, ref int TimeUnit);
        [DllImport("St7API.dll")]
        public static extern int St7SetResFileQuantity(int uID, int CaseNum, int Entity, int Quantity);
        [DllImport("St7API.dll")]
        public static extern int St7ClearResFileQuantity(int uID, int CaseNum, int Entity, int Quantity);
        [DllImport("St7API.dll")]
        public static extern int St7GetResFileQuantity(int uID, int CaseNum, int Entity, int Quantity, ref byte State);
        [DllImport("St7API.dll")]
        public static extern int St7SetResFileNodeResult(int uID, int CaseNum, int Node, int Quantity, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetResFileNodeResult(int uID, int CaseNum, int Node, int Quantity, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetResFileBeamResult(int uID, int CaseNum, int Beam, int Quantity, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetResFileBeamResult(int uID, int CaseNum, int Beam, int Quantity, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetResFileBeamStations(int uID, int CaseNum, int Stations);
        [DllImport("St7API.dll")]
        public static extern int St7GetResFileBeamStations(int uID, int CaseNum, ref int Stations);
        [DllImport("St7API.dll")]
        public static extern int St7SetResFilePlateResult(int uID, int CaseNum, int Plate, int Quantity, byte NonlinearMaterial, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetResFilePlateResult(int uID, int CaseNum, int Plate, int Quantity, ref byte NonlinearMaterial, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetResFileBrickResult(int uID, int CaseNum, int Brick, int Quantity, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetResFileBrickResult(int uID, int CaseNum, int Brick, int Quantity, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7ToolAlignBeamAxes(int uID, int BeamNum, int BeamAxis, int BeamAxisType, int UCSAxis, int UCSId);
        [DllImport("St7API.dll")]
        public static extern int St7ToolAlignPlateAxes(int uID, int PlateNum, int PlateAxis, int UCSAxis, int UCSId);
        [DllImport("St7API.dll")]
        public static extern int St7ToolConvertPatchLoads(int uID, int CaseNum, byte Overwrite);
        [DllImport("St7API.dll")]
        public static extern int St7ToolAttachParts(int uID, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7ToolPolygonToFace(int uID, int[] Integers, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7ZipMesh(int uID, double Tol, int TolType);
        [DllImport("St7API.dll")]
        public static extern int St7SetBeamSectionProperties(int uID, int PropNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7CalcBeamSectionProperties(int uID, int PropNum, int ExactJ);
        [DllImport("St7API.dll")]
        public static extern int St7AddNonlinearIncrement(int uID, string Name);
        [DllImport("St7API.dll")]
        public static extern int St7InsertNonlinearIncrement(int uID, int Pos, string Name);
        [DllImport("St7API.dll")]
        public static extern int St7DeleteNonlinearIncrement(int uID, int Pos);
        [DllImport("St7API.dll")]
        public static extern int St7SetNonlinearLoadIncrementFactor(int uID, int Increment, int CaseNum, double Factor);
        [DllImport("St7API.dll")]
        public static extern int St7SetNonlinearFreedomIncrementFactor(int uID, int Increment, int CaseNum, double Factor);
        [DllImport("St7API.dll")]
        public static extern int St7GetNonlinearLoadIncrementFactor(int uID, int Increment, int CaseNum, ref double Factor);
        [DllImport("St7API.dll")]
        public static extern int St7GetNonlinearFreedomIncrementFactor(int uID, int Increment, int CaseNum, ref double Factor);
        [DllImport("St7API.dll")]
        public static extern int St7AddLoadCaseCombination(int uID, string Name);
        [DllImport("St7API.dll")]
        public static extern int St7InsertLoadCaseCombination(int uID, int Pos, string Name);
        [DllImport("St7API.dll")]
        public static extern int St7DeleteLoadCaseCombination(int uID, int Pos);
        [DllImport("St7API.dll")]
        public static extern int St7SetLoadCaseCombinationFactor(int uID, int CombinationNum, int CaseNum, double Factor);
        [DllImport("St7API.dll")]
        public static extern int St7GetLoadCaseCombinationFactor(int uID, int CombinationNum, int CaseNum, ref double Factor);
        [DllImport("St7API.dll")]
        public static extern int St7EnableNonlinearLoadCase(int uID, int CaseNum);
        [DllImport("St7API.dll")]
        public static extern int St7DisableNonlinearLoadCase(int uID, int CaseNum);
        [DllImport("St7API.dll")]
        public static extern int St7EnableNonlinearFreedomCase(int uID, int CaseNum);
        [DllImport("St7API.dll")]
        public static extern int St7DisableNonlinearFreedomCase(int uID, int CaseNum);
        [DllImport("St7API.dll")]
        public static extern int St7GetNonlinearLoadCaseState(int uID, int CaseNum, ref byte State);
        [DllImport("St7API.dll")]
        public static extern int St7GetNonlinearFreedomCaseState(int uID, int CaseNum, ref byte State);
        [DllImport("St7API.dll")]
        public static extern int St7EnableFrequencyNSMassCase(int uID, int CaseNum);
        [DllImport("St7API.dll")]
        public static extern int St7DisableFrequencyNSMassCase(int uID, int CaseNum);
        [DllImport("St7API.dll")]
        public static extern int St7GetFrequencyNSMassCaseState(int uID, int CaseNum, ref byte State);
        [DllImport("St7API.dll")]
        public static extern int St7GetBeamResult(int uID, int ResultType, int BeamNum, int MinStations, int ResultCase, ref int NumStations, ref int NumColumns, double[] BeamPos, double[] BeamRes);
        [DllImport("St7API.dll")]
        public static extern int St7GetBeamForceResultPos(int uID, int BeamNum, int ResultCase, double Position, double[] BeamRes);
        [DllImport("St7API.dll")]
        public static extern int St7GetBeamResultPos(int uID, int ResultType, int BeamNum, int ResultCase, int NumStations, double[] BeamPos, ref int NumColumns, double[] BeamRes);
        [DllImport("St7API.dll")]
        public static extern int St7GetBeamDispResultPos(int uID, int BeamNum, int ResultCase, double Position, double[] LocalDisp, double[] GlobalDisp);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlateResult(int uID, int ResultType, int ResultSubType, int PlateNum, int ResultCase, int SampleLocation, int Surface, ref int NumPoints, ref int NumColumns, double[] PlateRes);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlateResultUCS(int uID, int ResultType, int UCSId, int PlateNum, int ResultCase, int SampleLocation, int Surface, ref int NumPoints, ref int NumColumns, double[] PlateRes);
        [DllImport("St7API.dll")]
        public static extern int St7GetBrickResult(int uID, int ResultType, int ResultSubType, int BrickNum, int ResultCase, int SampleLocation, ref int NumPoints, ref int NumColumns, double[] BrickRes);
        [DllImport("St7API.dll")]
        public static extern int St7GetBrickResultUCS(int uID, int ResultType, int UCSId, int BrickNum, int ResultCase, int SampleLocation, ref int NumPoints, ref int NumColumns, double[] BrickRes);
        [DllImport("St7API.dll")]
        public static extern int St7GetUserSpectralName(int uID, StringBuilder FileName, int MaxStringLen);
        [DllImport("St7API.dll")]
        public static extern int St7SetNodeKTranslation3(int uID, int NodeNum, int UCSId, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetNodeKRotation3(int uID, int NodeNum, int UCSId, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetNodeKDamping3(int uID, int NodeNum, int UCSId, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetNodeNSMass2(int uID, int NodeNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetBeamSupport2(int uID, int BeamNum, int Status, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetBeamDLL4(int uID, int BeamNum, int BeamDir, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetBeamDML4(int uID, int BeamNum, int BeamDir, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetBeamDLG4(int uID, int BeamNum, int BeamDir, int ProjectFlag, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetBeamCFL4(int uID, int BeamNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetBeamCFG4(int uID, int BeamNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetBeamCML4(int uID, int BeamNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetBeamCMG4(int uID, int BeamNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetBeamNSMass7ID(int uID, int BeamNum, int CaseNum, int DLType, int ID, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetPipePressure2(int uID, int BeamNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetPipeTemperature2(int uID, int BeamNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetBeamPreTension1(int uID, int BeamNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlatePreStress3(int uID, int PlateNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlateFaceSupport1(int uID, int PlateNum, int Status, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlateEdgeSupport1(int uID, int PlateNum, int EdgeNum, int Status, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlateNSMass2(int uID, int PlateNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlateConvection2(int uID, int PlateNum, int CaseNum, int EdgeNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetPlateRadiation2(int uID, int PlateNum, int CaseNum, int EdgeNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetBrickSupport1(int uID, int BrickNum, int FaceNum, int Status, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetBrickPreStress3(int uID, int BrickNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetBrickNSMass2(int uID, int BrickNum, int FaceNum, int CaseNum, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7EnableLoadCase(int uID, int CaseNum);
        [DllImport("St7API.dll")]
        public static extern int St7DisableLoadCase(int uID, int CaseNum);
        [DllImport("St7API.dll")]
        public static extern int St7GetLoadCaseStatus(int uID, int CaseNum, ref int OnOff);
        [DllImport("St7API.dll")]
        public static extern int St7SetLinearBucklingInitialFile(int uID, string FileName, int CaseNum);
        [DllImport("St7API.dll")]
        public static extern int St7GetLinearBucklingInitialFile(int uID, StringBuilder FileName, ref int CaseNum, int MaxStringLen);
        [DllImport("St7API.dll")]
        public static extern int St7SetNaturalFrequencyInitialFile(int uID, string FileName, int CaseNum);
        [DllImport("St7API.dll")]
        public static extern int St7GetNaturalFrequencyInitialFile(int uID, StringBuilder FileName, ref int CaseNum, int MaxStringLen);
        [DllImport("St7API.dll")]
        public static extern int St7SetNonlinearStaticInitialFile(int uID, string FileName, int CaseNum);
        [DllImport("St7API.dll")]
        public static extern int St7GetNonlinearStaticInitialFile(int uID, StringBuilder FileName, ref int CaseNum, int MaxStringLen);
        [DllImport("St7API.dll")]
        public static extern int St7SetNonlinearTransientInitialFile(int uID, string FileName, int CaseNum);
        [DllImport("St7API.dll")]
        public static extern int St7GetNonlinearTransientInitialFile(int uID, StringBuilder FileName, ref int CaseNum, int MaxStringLen);
        [DllImport("St7API.dll")]
        public static extern int St7SetLinearTransientInitialFile(int uID, string FileName, int CaseNum);
        [DllImport("St7API.dll")]
        public static extern int St7GetLinearTransientInitialFile(int uID, StringBuilder FileName, ref int CaseNum, int MaxStringLen);
        [DllImport("St7API.dll")]
        public static extern int St7SetTransientHeatInitialFile(int uID, string FileName, int CaseNum);
        [DllImport("St7API.dll")]
        public static extern int St7GetTransientHeatInitialFile(int uID, StringBuilder FileName, ref int CaseNum, int MaxStringLen);
        [DllImport("St7API.dll")]
        public static extern int St7SetModalDampingType(int uID, int DampType);
        [DllImport("St7API.dll")]
        public static extern int St7GetModalDampingType(int uID, ref int DampType);
        [DllImport("St7API.dll")]
        public static extern int St7SetHarmonicRange(int uID, int NumSteps, double F1, double F2);
        [DllImport("St7API.dll")]
        public static extern int St7GetHarmonicRange(int uID, ref int NumSteps, ref double F1, ref double F2);
        [DllImport("St7API.dll")]
        public static extern int St7SetHeatLoadCase(int uID, int CaseNum);
        [DllImport("St7API.dll")]
        public static extern int St7GetHarmonicBaseVector(int uID, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetHarmonicBaseVector(int uID, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetHarmonicLoadType(int uID, int hType);
        [DllImport("St7API.dll")]
        public static extern int St7GetHarmonicLoadType(int uID, ref int hType);
        [DllImport("St7API.dll")]
        public static extern int St7SetLSAFreedomCase(int uID, int CaseNum);
        [DllImport("St7API.dll")]
        public static extern int St7SetSolverLogicalParameter(int uID, int Parameter, byte Value);
        [DllImport("St7API.dll")]
        public static extern int St7GetSolverLogicalParameter(int uID, int Parameter, ref byte Value);
        [DllImport("St7API.dll")]
        public static extern int St7SetSolverIntegerParameter(int uID, int Parameter, int Value);
        [DllImport("St7API.dll")]
        public static extern int St7GetSolverIntegerParameter(int uID, int Parameter, ref int Value);
        [DllImport("St7API.dll")]
        public static extern int St7SetSolverDoubleParameter(int uID, int Parameter, double Value);
        [DllImport("St7API.dll")]
        public static extern int St7GetSolverDoubleParameter(int uID, int Parameter, ref double Value);
        [DllImport("St7API.dll")]
        public static extern int St7GetAttribute(int uID, int Entity, int EltNum, int AttributeType, int LocalID, int CaseNum, double[] AttributeDoubles, byte[] AttributeLogicals, ref int TypeId);
        [DllImport("St7API.dll")]
        public static extern int St7GetAttributeID(int uID, int Entity, int EltNum, int AttributeType, int LocalID, int CaseNum, int ID, double[] AttributeDoubles, byte[] AttributeLogicals, ref int TypeId);
        [DllImport("St7API.dll")]
        public static extern int St7GetElementGroup(int uID, int Entity, int EltNum, ref int GroupID);
        [DllImport("St7API.dll")]
        public static extern int St7SetElementGroup(int uID, int Entity, int EltNum, int GroupID);
        [DllImport("St7API.dll")]
        public static extern int St7DeleteAttributeID(int uID, int Entity, int EltNum, int AttributeType, int LocalID, int CaseNum, int ID);
        [DllImport("St7API.dll")]
        public static extern int St7NewTable(int uID, string TableName, int TableType, int NumEntries, double[] Doubles, ref int TableID);
        [DllImport("St7API.dll")]
        public static extern int St7DeleteTable(int uID, int TableID);
        [DllImport("St7API.dll")]
        public static extern int St7GetTableType(int uID, int TableID, ref int TableType);
        [DllImport("St7API.dll")]
        public static extern int St7GetTableName(int uID, int TableID, StringBuilder TableName, int MaxStringLen);
        [DllImport("St7API.dll")]
        public static extern int St7GetNumTableRows(int uID, int TableID, ref int NumRows);
        [DllImport("St7API.dll")]
        public static extern int St7GetTableData(int uID, int TableID, int MaxRows, ref int NumRows, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetTableData(int uID, int TableID, int NumEntries, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7SetLinkData(int uID, int LinkNum, int LinkType, int[] LinkData);
        [DllImport("St7API.dll")]
        public static extern int St7GetLinkData(int uID, int LinkNum, ref int LinkType, int[] LinkData);
        [DllImport("St7API.dll")]
        public static extern int St7SetLinkDoubles(int uID, int LinkNum, int LinkType, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetLinkDoubles(int uID, int LinkNum, ref int LinkType, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetBeamProperty(int uID, int PropNum, ref int BeamType, ref int SectionType, ref int MirrorType, double[] SectionData, double[] BeamMaterial);
        [DllImport("St7API.dll")]
        public static extern int St7GetPlateProperty(int uID, int PropNum, double[] SectionData, double[] PlateMaterial);
        [DllImport("St7API.dll")]
        public static extern int St7GetBrickProperty(int uID, int PropNum, double[] BrickMaterial);
        [DllImport("St7API.dll")]
        public static extern int St7SetTransientInitialConditions(int uID, double[] Doubles);
        [DllImport("St7API.dll")]
        public static extern int St7GetTransientInitialConditions(int uID, double[] Doubles);
    }
}
