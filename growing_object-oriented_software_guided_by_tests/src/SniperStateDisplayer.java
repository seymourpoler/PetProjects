public class SniperStateDisplayer implements SniperListener {
    private UI ui;

    private final String STATUS_WINNIG = "winning";
    private final String STATUS_LOST = "lost";
    private final String STATUS_BIDDING = "bidding";

    public SniperStateDisplayer(UI ui) {
        this.ui = ui;
    }

    public void sniperLost() {
        ui.showStatus(STATUS_LOST);
    }

    public void sniperBidding() {
        ui.showStatus(STATUS_BIDDING);
    }

    public void sniperWinning(){
        ui.showStatus(STATUS_WINNIG);
    }
}
